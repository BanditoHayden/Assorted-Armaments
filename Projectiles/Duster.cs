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
    public class Duster : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 5;
            Projectile.height = 5;
            Projectile.hostile = false;
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
        public override void Kill(int timeLeft)
        {
            /*for (int i = 0; i < 180; i++)
            {
                Vector2 dustPos = Projectile.Center + new Vector2(46, 0).RotatedBy(MathHelper.ToRadians(i * 2));
                Dust dust = Dust.NewDustPerfect(dustPos, ModContent.DustType<GhostDust>());
                dust.noGravity = true;
            }*/
            for (int i = 0; i < 50; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust d = Dust.NewDustPerfect(Projectile.Center, DustID.WhiteTorch, speed * 5, Scale: 1.5f);
                d.noGravity = true;
            }

        }
    }
}

