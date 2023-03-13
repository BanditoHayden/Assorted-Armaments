using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Assortedarmaments.Projectiles;
using Terraria.DataStructures;

namespace Assortedarmaments.Items.Weapons.Ranged
{
    public class ServiceRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TEST GUN");
            SacrificeTotal = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            Item.rare = 1;
            Item.value = Item.buyPrice(gold: 50);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;
            // Weapon Properties
            Item.damage = 20;
            Item.knockBack = 5f;
            Item.crit = 21;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            //Item.shoot = ProjectileID.Bullet;
            Item.shoot = ModContent.ProjectileType<SineWave>();

            Item.shootSpeed = 10f;
         //  Item.useAmmo = AmmoID.Bullet;
        }
       

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
        public override void AddRecipes()
        {
            
        }
    }
}
