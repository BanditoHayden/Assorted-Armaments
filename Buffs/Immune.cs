using System;
using Assortedarmaments.Assets.Common;
using Assortedarmaments.Items.Weapons.Ranged;
using System.Numerics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Buffs
{
    public class Immune : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Description.SetDefault("");
            DisplayName.SetDefault("");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = true;
        }

    }
}

