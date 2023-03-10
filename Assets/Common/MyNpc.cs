using Assortedarmaments.Items.Accessory;
using Assortedarmaments.Items.Consumable;
using Assortedarmaments.Items.Tools;
using Assortedarmaments.Items.Weapons.Magic;
using Assortedarmaments.Items.Weapons.Melee;
using Assortedarmaments.Items.Weapons.Ranged;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Chat;
using Terraria.GameContent.ItemDropRules;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Common
{
    public class MyNpc : GlobalNPC
    {
        public bool slowness;
        int arg;
        public override void ResetEffects(NPC npc)
        {
            slowness = false;
        }
        public override bool InstancePerEntity => true;
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Dryad)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<StrawberryHeart>());
                nextSlot++;
               

            }
            if (Main.hardMode)
            {
                if (type == NPCID.SkeletonMerchant)
                {
                    shop.item[nextSlot].SetDefaults(ModContent.ItemType<OldNail>());
                }

            }

        }

        public override void SetupTravelShop(int[] shop, ref int nextSlot)
        {
            if (Main.rand.NextBool(5))
            {
                shop[nextSlot] = ModContent.ItemType<HeartSynthesizer>();
                nextSlot++;
            }

          
        }
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {

            if (npc.type == NPCID.Bunny)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RabbitsFoot>(), 75));
            }
            if (npc.type == NPCID.GoldBunny)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GoldenRabbitsFoot>(), 20));
            }
            if (npc.type == NPCID.GoblinPeon || npc.type == NPCID.GoblinSorcerer || npc.type == NPCID.GoblinThief || npc.type == NPCID.GoblinWarrior)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<WarPick>(), 95));
            }
            if (npc.type == NPCID.Harpy)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AeroScimitar>(), 200));
            }
            if (npc.type == NPCID.BlueJellyfish)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FriendshipBracelet>(), 30));
            }
            if (npc.type == NPCID.GreenJellyfish)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FriendshipBracelet>(), 30));
            }
            if (npc.type == NPCID.PinkJellyfish)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FriendshipBracelet>(), 30));

            }
            if (npc.type == NPCID.Mothron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkDawn>(), 10));
            }
            if (npc.type == NPCID.Ghost)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonlightGreatsword>(), 200));
            }
            if (npc.type == NPCID.SkeletronPrime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (npc.type == NPCID.Retinazer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (npc.type == NPCID.Spazmatism)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (npc.type == NPCID.TheDestroyer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Polyute>(), 15));

            }
            if (npc.type == NPCID.QueenSlimeBoss)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Infinity>(), 10));

            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Diplopia>(), 10));

            }
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Hourglass>(), 10));

            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brainstalks>(), 10));

            }
            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HunnyPot>(), 10));

            }
            if (npc.type == NPCID.SkeletronHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrittleBones>(), 10));

            }
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CursedT>(), 10));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EternalFlames>(), 5));


            }
        }
       
       
       

        public override void OnKill(NPC npc)
        {

          
        }
    }
}
