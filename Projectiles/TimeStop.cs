using Assortedarmaments.Buffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Projectiles
{
    public class TimeStop : ModProjectile
    {
     
        public override void SetDefaults()
        {
            Projectile.width = 1500;
            Projectile.height = 1500;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] >= 1f)
            {
                
                Projectile.velocity *= 1.05f;
            }
            if (Projectile.ai[0] >= 10f)
            {
                Projectile.velocity = Microsoft.Xna.Framework.Vector2.Zero;

            }
            if (Main.netMode != NetmodeID.Server)
            {
                 Filters.Scene.Activate("Shockwave", Projectile.Center).GetShader().UseColor(20, 20, 10).UseTargetPosition(Projectile.Center);

            }
            if (Main.netMode != NetmodeID.Server && Filters.Scene["Shockwave"].IsActive())
            {
                Filters.Scene["Shockwave"].GetShader().UseProgress(1).UseOpacity(500);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           
            
                target.AddBuff(ModContent.BuffType<SlimeSlow>(), 120);
            Projectile.friendly = false;
        }
        public override void Kill(int timeLeft)
        {
            Filters.Scene["Shockwave"].Deactivate();
        }
      
    }
}
