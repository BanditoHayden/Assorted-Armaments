using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Assortedarmaments.Projectiles;
using Assortedarmaments.Assets.Common;
using Assortedarmaments.Assets.Systems;
using System.Collections.Generic;
using Assortedarmaments.Buffs;
using Assortedarmaments.Assets.Rarities;

namespace Assortedarmaments.Items.Weapons.Melee
{
    public class MoonlightGreatsword : ModItem
    {
        int currentAttack = 1;
        int attackcycle = 0;


        public override void SetStaticDefaults()
        {

            SacrificeTotal = 1;
            Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ModContent.RarityType<Legendary>();

            Item.width = 68;
            Item.height = 68;
          //  Item.noUseGraphic = true;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 35;
            Item.useTime = 35;
            Item.reuseDelay = 2;

            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
         //   Item.channel = true;
            Item.value = Item.sellPrice(gold: 40);

            // Weapon Properties
            Item.damage = 50;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<MoonlightSlash>();
            Item.shootSpeed = 10f;

        }
        public override bool CanUseItem(Player player)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (modPlayer.Upgrade1)
            {
                Item.damage = 110;
            }
            if (modPlayer.Upgrade2)
            {
                Item.damage = 1100;
            }
        

            return true;
        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Assortedarmaments", $"Press {Keybinds.Legendary?.GetAssignedKeys()[0] ?? "UNBOUND"} To acquire moonlights blessing!\nWhile affected by Moonlights blessing, the Moonlight Greatsword gains increased stats and fires projectiles\nAt [c/07EBF2:Tier 2] has a chance to deal 10x damage\nAt [c/07EBF2:Tier 3] has a chance to deal 100x damage\n[c/07EBF2:Legendary Armament]"));
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            int dir = currentAttack;
            if (player.HasBuff<MoonlightBlessing>())
            {
                Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<MoonlightSlash>(), damage, knockback, player.whoAmI);

            }
            /*currentAttack = -currentAttack;
            attackcycle = (attackcycle + 1) % 2;
            if (Main.rand.NextBool(10))
            {
                if (modPlayer.Upgrade1)
                {
                    Projectile.NewProjectile(source, position, velocity, type, damage * 10, knockback, player.whoAmI, 1, attackcycle);

                }
                if (modPlayer.Upgrade2)
                {
                    Projectile.NewProjectile(source, position, velocity, type, damage * 100, knockback, player.whoAmI, 1, attackcycle);

                }

            }
            else
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1, attackcycle);

            
            return false;
            */
            return false;

        }


    }
}
