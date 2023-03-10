﻿using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria.ModLoader;

namespace Assortedarmaments.Items.Consumable.Alcohol
{
    public class RyeWhiskey : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;

            Tooltip.SetDefault("Increases summon damage by 10%, but your grounded");
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
            Item.value = Item.buyPrice(gold: 15);
            Item.buffType = ModContent.BuffType<Buffs.Consumable.RyeWhiskeyBuff>();
            Item.buffTime = 3600;
        }
      
        

    }
}