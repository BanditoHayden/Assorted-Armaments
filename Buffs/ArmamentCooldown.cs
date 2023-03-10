using Assortedarmaments.Assets.Common;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Buffs
{
    public class ArmamentCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armament Cooldown");
            Description.SetDefault("You are unable to unleash your armaments legendary ability");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
        }

    }
}

