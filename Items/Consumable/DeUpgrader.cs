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
    public class DeUpgrader : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;

            Tooltip.SetDefault("test item\nRight click checks for Upgrade1 And Upgrade2");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(gold: 10);

        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool? UseItem(Player player)
        {

            MyPlayer modPlayer = player.GetWorldPlayer();
            
            if (modPlayer.Upgrade1)
            {
                modPlayer.Upgrade1 = false;
            }
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (player.altFunctionUse == 2)
            {
                Main.NewText(modPlayer.Upgrade1);
            }
            if (modPlayer.Upgrade1)
            {
                modPlayer.Upgrade1 = false;
                return true;
            }
            else return false;
        }
    }
}