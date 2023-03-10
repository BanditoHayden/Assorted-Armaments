using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Assortedarmaments.Assets.Common;

namespace Assortedarmaments.Items.Accessory
{
    public class HeartSynthesizer : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heart Synthesizer");
            Tooltip.SetDefault("Projectiles have a chance to spawn a heart");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().HeartSynthesizer = true;
        }

    }
}
