using Assortedarmaments.Assets.Systems;
using Assortedarmaments.Buffs;
using Assortedarmaments.Items.Weapons.Melee;
using Assortedarmaments.Items.Weapons.Ranged;
using Assortedarmaments.Projectiles;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Physics;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using static tModPorter.ProgressUpdate;

namespace Assortedarmaments.Assets.Common
{
    public class MyPlayer : ModPlayer
    {
        public bool Pickaxe = false;
        public bool Diplopia;
        public bool Hourglass;
        public bool CursedTrident;
        public float ScreenShake;
        public bool Bones;
        public bool Bees;
        public bool SilverBullets;
        public bool HeavyBullets;
        public bool HunnyPot;
        public bool Loaded;
        public bool HeartSynthesizer;
        public bool canDoubleJump;
        public bool DoubleJump;
        public bool waitDoubleJump;
        public bool Polyute;
        public bool Upgrade1;
        public bool Upgrade2;


       
        public override void ResetEffects()
        {
            Diplopia = false;
            Hourglass = false;
            Bones = false;
            CursedTrident = false;
            Bees = false;
            SilverBullets = false;
            HeavyBullets = false;
            HunnyPot = false;
            HeartSynthesizer = false;
            canDoubleJump = false;
            Polyute = false;
        }

      
        public override void ModifyScreenPosition()
        {
            if (ScreenShake > 0.1f)
            {
                Main.screenPosition += new Vector2(Main.rand.NextFloat(ScreenShake), Main.rand.NextFloat(ScreenShake));

                ScreenShake *= 0.9f;
            }
        }
        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (Bones)
            {
                if (Player.statLife <= 100 && !Player.HasBuff<BrokenBones2>())
                {

                    Player.AddBuff(ModContent.BuffType<BrokenBones>(), 1);
                    Player.AddBuff(ModContent.BuffType<BrokenBones2>(), 999);
                }
                if (Player.statLife >= 101 && Player.HasBuff<BrokenBones2>())
                {
                    Player.ClearBuff(ModContent.BuffType<BrokenBones2>());
                }
            }
           

            if (Player.HeldItem.type != ModContent.ItemType<PainTrain>() && Player.HasBuff(ModContent.BuffType<Steamy>()))
            {
                Player.ClearBuff(ModContent.BuffType<Steamy>());

            }
          

        

        }
      
        public override void PreUpdateMovement()
        {
            if (canDoubleJump)
            {
                // Credit to BlueMoonJune
                if (Player.velocity.Y >= 0f && Collision.SolidCollision(Player.BottomLeft, 32, 8, true))
                {
                    {
                        DoubleJump = true;
                        waitDoubleJump = true;

                    }
                }
                else
                {
                    if (DoubleJump && Player.controlJump && !waitDoubleJump)
                    {
                        if (Player.jump > 0)
                        {
                            waitDoubleJump = true;
                            return;
                        }
                        Player.velocity.Y = (0f - Player.jumpSpeed) * Player.gravDir;
                        Player.jump = (int)(Player.jumpHeight);
                        DoubleJump = false;





                        //SoundEngine.PlaySound(new SoundStyle("Techarria/Content/Sounds/Boing"), Player.position);
                        for (int i = 0; i < 10; i++)
                            Dust.NewDust(Player.TopLeft, Player.width, Player.height, Terraria.ID.DustID.Clentaminator_Red);

                    }
                    waitDoubleJump = Player.controlJump;
                }


            }

        }
        public override void PostUpdate()
        {
            if (Player.HasBuff(ModContent.BuffType<Steamy>()))
            {
                Player.statDefense /= 2;
            }
        }
        public override void PostUpdateRunSpeeds()
        {
            if (Player.HeldItem.type == ModContent.ItemType<AeroScimitar>())
            {
                Player.runAcceleration += 0.25f;
                Player.maxRunSpeed += 0.25f;
            }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            bool CursedTridentHotkey = Keybinds.CursedTrident.JustPressed;
            bool TimestopHotkey = Keybinds.Timestop.JustPressed;
            bool HunnyPotHotkey = Keybinds.HunnyPot.JustPressed;
            bool LegendaryHoteky = Keybinds.Legendary.JustPressed;

            var entitySource = Player.GetSource_FromThis();
            Vector2 velocity = Vector2.One;
            var  type = ModContent.ProjectileType<CursedTrident>();
            int AmountHurt = Player.statLifeMax2/4;
            if (CursedTridentHotkey && CursedTrident && !Player.dead)
            {
                Player.Hurt(PlayerDeathReason.ByCustomReason(("Claimed by the underworld")), AmountHurt, 1);
                Projectile.NewProjectile(entitySource, Main.MouseWorld, velocity, type, 300, 1, Player.whoAmI);
            }
            if (TimestopHotkey && Hourglass && !Player.dead && !Player.HasBuff(BuffID.PotionSickness))
            {
                 SoundStyle ZAWARUDO = new SoundStyle ($"{nameof(Assortedarmaments)}/Assets/Sounds/Items/Guns/ZAWARUDO");
                SoundEngine.PlaySound(ZAWARUDO);
                Player.AddBuff(BuffID.PotionSickness, 3600);
                Projectile.NewProjectile(entitySource, Player.Center, velocity, ModContent.ProjectileType<TimeStop>(), 1, 1, Player.whoAmI);
            }
            if (HunnyPotHotkey && HunnyPot && !Player.dead && !Player.HasBuff(ModContent.BuffType<HunnySickness>()))
             {
                Player.AddBuff(ModContent.BuffType<HunnySickness>(), 3600);

                Player.Heal(120);
            }
            
            if (LegendaryHoteky)
            {
                if (Player.HeldItem.type == ModContent.ItemType<AeroScimitar>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    int damage = Player.HeldItem.damage;
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);
                    Projectile.NewProjectile(entitySource, Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<GiantTornado>(), damage, 1, Player.whoAmI);
                    SoundEngine.PlaySound(SoundID.DD2_BetsyWindAttack);
                }
               
                if (Player.HeldItem.type == ModContent.ItemType<PainTrain>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);

                    SoundStyle TrainBro = new SoundStyle($"{nameof(Assortedarmaments)}/Assets/Sounds/Items/Guns/Train");
                    SoundEngine.PlaySound(TrainBro);
                    Player.AddBuff(ModContent.BuffType<Steamy>(), 360);

                }
                if (Player.HeldItem.type == ModContent.ItemType<MoonlightGreatsword>() && !Player.HasBuff(ModContent.BuffType<ArmamentCooldown>()))
                {
                    Player.AddBuff(ModContent.BuffType<ArmamentCooldown>(), 3600);

                    SoundEngine.PlaySound(SoundID.Item29);
                    Player.AddBuff(ModContent.BuffType<MoonlightBlessing>(), 720);

                }
               
            }
          
        }
       
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (HeartSynthesizer)
            {
                if (Main.rand.NextBool(150)) // Player.HeldItem.shootSpeed
                {
                    Item.NewItem(proj.GetSource_FromThis(), target.getRect(), ItemID.Heart);

                }
            }
        }
        public override bool Shoot(Item item, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Bees)
            {
                const int NumProjectiles = 1;
                if (Main.rand.NextBool(20))
                {
                    for (int i = 0; i < NumProjectiles; i++)
                    {
                        Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                        newVelocity *= 1f - Main.rand.NextFloat(0.3f);
                        Projectile.NewProjectile(source, position, velocity, ProjectileID.Bee, damage, knockback, Player.whoAmI);

                    }
                }

            }
           
            return true;

        }
        
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (SilverBullets && proj.CountsAsClass(DamageClass.Ranged))
            {
                if (target.boss)
                {
                    damage += (int)(damage * 0.5f);
                }
                else
                {
                    damage /= 2;
                }
            }
        }
    }
}
