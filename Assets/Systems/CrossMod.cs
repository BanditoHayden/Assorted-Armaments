using Assortedarmaments.Assets.Common;
using Assortedarmaments.Items.Consumable;
using Assortedarmaments.Items.Weapons.Ranged;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace Assortedarmaments.Assets.Systems
{
    public class CrossMod : ModSystem
    {

        public override void PostSetupContent()
        {

            DoCensusIntegration();

        }
        private void DoCensusIntegration()
        {

            if (!ModLoader.TryGetMod("Census", out Mod censusMod))
            {
                return;
            }

            int npcType = ModContent.NPCType<Npc.Town.Cowboy>();

            string message = "Spawns after beating Eye Of Cthulu";
            censusMod.Call("TownNPCCondition", npcType, message);


        }
        public override void AddRecipes()
        {
            ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
            Recipe recipe = Recipe.Create(ModContent.ItemType<Upgrader2>());
            if (Calamity != null && Calamity.TryFind<ModItem>("AuricBar", out ModItem AuricBar))
            {
                recipe.AddIngredient(AuricBar.Type, 5);
                recipe.AddIngredient(ModContent.ItemType<Upgrader>());
                recipe.Register();

            }


        }
    }
}
