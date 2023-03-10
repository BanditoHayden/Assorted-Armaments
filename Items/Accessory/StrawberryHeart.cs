﻿using Assortedarmaments.Assets.Common;
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
    public class StrawberryHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
          
            Tooltip.SetDefault("Grants a double jump");
        }

        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.Red;
        }


        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().canDoubleJump = true;
            
        }

    }
}
