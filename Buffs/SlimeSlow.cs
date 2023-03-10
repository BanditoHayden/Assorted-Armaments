using Assortedarmaments.Assets.Common;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Buffs
{
    public class SlimeSlow : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("stop debuff");
            Description.SetDefault("test");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<MyNpc>().slowness = true;
            if (!npc.boss && npc.HasBuff<SlimeSlow>())
            {
                npc.velocity.X *= 0f;
                npc.velocity.Y *= 0f;

            }
         

        }
    }
}

