using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Rarities
{
    public class Legendary : ModRarity
    {

        public override Color RarityColor
        {
            get
            {
                float time = Main.GameUpdateCount % 60 / 60f;  //Convert to a range of 0-1
                time *= MathHelper.TwoPi;  //Convert to a range of 0-2pi

                float sin = (float)Math.Sin(time) + 1;  //Convert from [-1, 1] to [0, 2]
                sin /= 2;  //Convert from [0, 2] to [0, 1]

                return Color.Lerp(Color.DarkBlue, Color.Cyan, sin);

            }
        }

    }
}
