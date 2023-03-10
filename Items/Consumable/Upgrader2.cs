using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using Assortedarmaments.Assets.Common;
using Assortedarmaments.Assets.Systems;

namespace Assortedarmaments.Items.Consumable
{
    public class Upgrader2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;

            Tooltip.SetDefault("Upgrades Legendary Armaments to Tier 3\nMust be favorited to work\nStat changes take place after favoriting the item I.E use the weapon so the stats can change");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 10);

        }
        public override void UpdateInventory(Player player)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();

            if (Item.favorited)
            {
                modPlayer.Upgrade2 = true;
            }
            else
                modPlayer.Upgrade2 = false;

        }
    }
}
