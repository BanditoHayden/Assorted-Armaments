using Assortedarmaments.Assets.Common;
using Assortedarmaments.Assets.Rarities;
using Assortedarmaments.Assets.Systems;
using Assortedarmaments.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;


namespace Assortedarmaments.Items.Weapons.Ranged
{
    public class PainTrain : ModItem
    {
        public override void SetStaticDefaults()
        {
            SacrificeTotal = 1;
        }
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 30;
            Item.height = 30;
            //Item.rare = ItemRarityID.Master;
            Item.rare = ModContent.RarityType<Legendary>();
            Item.value = Item.sellPrice(platinum: 1);
            Item.noMelee = true;
            // Use Properties
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            // Weapon Properties
            Item.damage = 5;
            Item.knockBack = 3f;
            Item.DamageType = DamageClass.Ranged;
            // Projectile Properties
            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool CanUseItem(Player player)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (modPlayer.Upgrade1)
            {
                Item.damage = 48;
            }
            if (modPlayer.Upgrade2)
            {
                Item.damage = 1050;
            }
           

            return true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            tooltips.Add(new TooltipLine(Mod, "Assortedarmaments", $"Press {Keybinds.Legendary?.GetAssignedKeys()[0] ?? "UNBOUND"} To release steam, which increases fire rate but lowers defense\n[c/07EBF2:Legendary Armament]"));
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}
