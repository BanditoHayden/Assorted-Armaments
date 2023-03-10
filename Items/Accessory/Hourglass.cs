using Assortedarmaments.Assets.Common;
using Assortedarmaments.Assets.Systems;
using Assortedarmaments.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Items.Accessory
{
    public class Hourglass : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hourglass");
            Tooltip.SetDefault("");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Assortedarmaments", $"ZA WARUDO\nPress {Keybinds.Timestop?.GetAssignedKeys()[0] ?? "UNBOUND"} To freeze enemies briefly\nInduces potion sickness"));
        }
        public override void SetDefaults()
        {
          
            Item.UseSound = new SoundStyle($"{nameof(Assortedarmaments)}/Assets/Sounds/Items/Guns/ZAWARUDO")
            {
                Volume = 1f,
                PitchVariance = 0.0f,
                MaxInstances = 3,
            };
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Blue;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().Hourglass = true;

        }

    
        
       
    }
}
