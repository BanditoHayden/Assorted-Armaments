using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Assortedarmaments.Buffs;
using Assortedarmaments.Assets.Common;
using Terraria.Audio;
using static Assortedarmaments.Assets.Common.Helpers;
using System.Threading;

namespace Assortedarmaments.Projectiles
{
    public class EyeProj : Boomerang
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.tileCollide = true;

        }
        int timer;
        public override void AI()
        {
            timer++;
            
                Projectile.velocity *= 0.98f;

            

            
           
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.position);
                if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }

                // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
                if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
            

            return false;
        }
      
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit13, Projectile.position);

            for (int i = 0; i < 50; i++)
            {
                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                Dust d = Dust.NewDustPerfect(Projectile.Center, DustID.VampireHeal, speed * 5, Scale: 1.5f);
                d.noGravity = true;
            }
        }
    }
}
