using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Projectiles
{
    public class EclipseProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            
        }

        public override void SetDefaults()
        {
            Projectile.width = 36;
            Projectile.height = 36;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 160;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = true;

        }



        public ref float StateTimer => ref Projectile.ai[1];
        public override void AI()
        {
            Projectile.rotation += 0.8f;

        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Mothron);
            }
        }
    }
}

