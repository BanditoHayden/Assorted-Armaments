using Terraria.ModLoader;

namespace Assortedarmaments.Assets.Systems
{
    public class Keybinds : ModSystem
    {
        public static ModKeybind CursedTrident { get; private set; }
        public static ModKeybind Timestop { get; private set; }
        public static ModKeybind HunnyPot { get; private set; }
        public static ModKeybind Legendary { get; private set; }


        public override void Load()
        {
            CursedTrident = KeybindLoader.RegisterKeybind(Mod, "Cursed Trident Activation", "P");
            Timestop = KeybindLoader.RegisterKeybind(Mod, "Timestop Activation", "O");
            HunnyPot = KeybindLoader.RegisterKeybind(Mod, "Hunny Pot Activation", "J");
            Legendary = KeybindLoader.RegisterKeybind(Mod, "Legendary Armament Activation", "K");
        }
        public override void Unload()
        {
            CursedTrident = null;
            Timestop = null;
            HunnyPot = null;
            Legendary = null;
        }
    }
}
