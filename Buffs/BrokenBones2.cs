using Assortedarmaments.Assets.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Buffs
{
    public class BrokenBones2 : ModBuff
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Bones!");
            Description.SetDefault("0 Defense\n+50% Damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense = 0;
            player.GetDamage(DamageClass.Generic) += 0.50f;
            player.lifeRegen = 0;
        }

    }
}

