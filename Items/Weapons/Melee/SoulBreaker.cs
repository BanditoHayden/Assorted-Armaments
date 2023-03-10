using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Assortedarmaments.Items.Materials;

namespace Assortedarmaments.Items.Weapons.Melee
{
    public class SoulBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 64;
            Item.height = 64;
            Item.rare = 1;
            Item.value = Item.sellPrice(silver: 1);
            Item.noMelee = false;
            // Use Properties
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 22;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            // Projectile Properties

        }
        public override void AddRecipes()
        {
            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.TissueSample, 7)
           .AddTile(TileID.Anvils)
           .Register();

            CreateRecipe()
           .AddIngredient(ModContent.ItemType<SoulPiece>(), 7)
           .AddIngredient(ItemID.ShadowScale, 7)
           .AddTile(TileID.Anvils)
           .Register();
        }
    }
}
