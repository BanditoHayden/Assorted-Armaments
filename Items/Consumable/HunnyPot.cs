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
    public class HunnyPot : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Assortedarmaments", $"Sweet Memories\nPress {Keybinds.HunnyPot?.GetAssignedKeys()[0] ?? "UNBOUND"} To heal yourself\nInduces hunny sickness"));
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().HunnyPot = true;
        }





    }
}
