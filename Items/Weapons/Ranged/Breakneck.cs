using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Assortedarmaments.Projectiles;

namespace Assortedarmaments.Items.Weapons.Ranged
{
    public class Breakenck : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Killing enemies grants onslaught\n");
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 7;
            Item.value = Item.buyPrice(gold: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 28;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ModContent.ProjectileType<DynastyProj>();
            Item.shootSpeed = 12f;
        }
       
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                      .AddIngredient(ItemID.DynastyWood, 20)
                       .AddIngredient(ItemID.VenusMagnum, 1)
                        .AddIngredient(ItemID.SoulofMight, 12)

                      .AddTile(TileID.AdamantiteForge)
                      .Register();
        }
    }
}
