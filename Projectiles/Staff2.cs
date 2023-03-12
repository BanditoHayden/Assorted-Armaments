using Assortedarmaments.Dusts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Projectiles
{
    public class Staff2 : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 5;
        }
        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                Projectile.tileCollide = false;

                Projectile.alpha = 255;
                Projectile.position = Projectile.Center;
                Projectile.Center = Projectile.position;
            }

            return;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];

            if (crit)
            {
                player.Heal(5);
            }
        }
        public override void Kill(int timeLeft)
        {

            for (int i = 0; i < 50; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust d = Dust.NewDustPerfect(Projectile.Center, DustID.ChlorophyteWeapon, speed * 5, Scale: 1.5f);
                d.noGravity = true;
            }

        }
    }
}
