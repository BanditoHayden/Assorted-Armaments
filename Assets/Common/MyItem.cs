using Assortedarmaments.Items.Accessory;
using Assortedarmaments.Items.Consumable;
using Assortedarmaments.Items.Weapons.Magic;
using Assortedarmaments.Items.Weapons.Melee;
using Assortedarmaments.Items.Weapons.Ranged;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Common
{
    public class MyItem : GlobalItem
    {
       
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {

            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorruptedJoustingLance>(), 4));

            }
            if (item.type == ItemID.SkeletronPrimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.TwinsBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.DestroyerBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (item.type == ItemID.QueenSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Infinity>(), 10));

            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Diplopia>(), 10));

            }
            if (item.type == ItemID.KingSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Hourglass>(), 10));

            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brainstalks>(), 10));

            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<HunnyPot>(), 10));

            }
            if (item.type == ItemID.SkeletronBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrittleBones>(), 10));

            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedT>(), 10));
                itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EternalFlames>(), 5));

            }
        }
    }
}

