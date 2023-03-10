using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Common
{
    public class Assortedarmaments : Mod
    {
        public static Dictionary<int, int> oreTileToItem;
        public static Dictionary<int, int> oreItemToTile;
        public static Effect Greyscale;

        public override void Load()
        {
            oreTileToItem = new Dictionary<int, int>();
            oreItemToTile = new Dictionary<int, int>();
            //Ref<Effect> Greyscale = new Ref<Effect>(ModContent.Request<Effect>("Assortedarmaments/Assets/Effects/Greyscale", AssetRequestMode.ImmediateLoad).Value);
            //GameShaders.Misc["Assortedarmaments:Greyscale"] = new MiscShaderData(Greyscale, "Greyscale");
            if (Main.netMode != NetmodeID.Server)
            {

                //  Ref<Effect> invertRef = new Ref<Effect>(ModContent.Request<Effect>("Assortedarmaments/Assets/Effects/Greyscale").Value);
                //  Ref<Effect> shockwaveRef = new Ref<Effect>(ModContent.Request<Effect>("Assortedarmaments/Assets/Effects/Greyscale").Value);
                // Filters.Scene["Assortedarmaments:Greyscale"] = new Filter(new ScreenShaderData(invertRef, "Greyscale"), EffectPriority.VeryHigh);
                // Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(shockwaveRef, "Shockwave"), EffectPriority.VeryHigh);
                
                    Ref<Effect> screenRef = new Ref<Effect>(ModContent.Request<Effect>("Assortedarmaments/Assets/Effects/Shockwave", AssetRequestMode.ImmediateLoad).Value);
                    Filters.Scene["Shockwave"] = new Filter(new ScreenShaderData(screenRef, "Shockwave"), EffectPriority.VeryHigh);
                    Filters.Scene["Shockwave"].Load();
                
            }
        }
        public override void Unload()
        {
            oreTileToItem = null;
            oreItemToTile = null;
        }
        public override void PostSetupContent()
        {
            for (int item = 0; item < ItemLoader.ItemCount; item++)
            {
                Item test = new Item();
                test.SetDefaults(item);
                int tile = test.createTile;
                if (tile > -1 && tile < TileLoader.TileCount && TileID.Sets.Ore[tile])
                {
                    if (!oreTileToItem.ContainsKey(tile))
                    {
                        oreTileToItem.Add(tile, item);
                    }

                    if (!oreItemToTile.ContainsKey(item))
                    {
                        oreItemToTile.Add(item, tile);
                    }
                }
            }
        }
    }
}