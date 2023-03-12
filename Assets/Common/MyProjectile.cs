using Assortedarmaments.Buffs;
using Assortedarmaments.Items.Weapons.Melee;
using Assortedarmaments.Items.Weapons.Ranged;
using Assortedarmaments.Projectiles;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Common
{
    public class MyProjectile : GlobalProjectile
    {
        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (modPlayer.HeavyBullets && projectile.friendly && projectile.CountsAsClass(DamageClass.Ranged))
            {
                
            }
            return true;
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            var entitySource = Projectile.GetSource_None();
            if (modPlayer.Polyute && projectile.friendly && Main.rand.NextBool(10))
            {
                Projectile.NewProjectile(entitySource, target.Center.X, target.Center.Y - 100, Main.rand.Next(20, 21) * .25f, Main.rand.Next(20,21) * .25f, ProjectileID.ChlorophyteBullet, player.HeldItem.damage, 0f, projectile.owner);

            }
            if (player.HeldItem.type == ModContent.ItemType<LivingWoodBow>())
            {
                if (crit)
                {
                    player.Heal(5);
                }
            }

        }
    }
}
