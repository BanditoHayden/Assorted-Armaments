using Assortedarmaments.Assets.Common;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Buffs
{
    public class BrokenBones : ModBuff
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
            Rectangle Rectangle = new Rectangle((int)player.position.X, (int)player.position.Y, 100, 100);
            CombatText.NewText(Rectangle, Color.Red, "Broken Bones!");
        }
       
    }
}

