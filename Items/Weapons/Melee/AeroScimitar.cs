
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

namespace Assortedarmaments.Items.Weapons.Melee
{
    public class AeroScimitar : ModItem
    {


        public override void SetDefaults()
        {

            // Common Properties
            Item.width = 60;
            Item.height = 60;
            // Use Properties
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.UseSound = SoundID.Item1;
            Item.reuseDelay = 2;

            Item.autoReuse = false;
            Item.rare = ModContent.RarityType<Legendary>();
            Item.value = Item.buyPrice(platinum: 1);
            // Weapon Properties
            Item.damage = 25;
            Item.knockBack = 2f;
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<Tornado>();
            Item.shootSpeed = 8f;
            // Projectile Properties
        }
        public override bool CanUseItem(Player player)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (modPlayer.Upgrade1)
            {
                Item.damage = 148;
            }
            if (modPlayer.Upgrade2)
            {
                Item.damage = 988;
            }
            

            return true;
        }
        int fired;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (modPlayer.Upgrade1)
            {
                fired++;
                if (fired < 6)
                {
                    Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, 1);
                }
                if (fired == 6)
                {
                    fired = 0;
                    Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<GiantTornado>(), damage, knockback, player.whoAmI);
                }
                return false;
            }
            return true;

        }
        
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            tooltips.Add(new TooltipLine(Mod, "Assortedarmaments", $"Press {Keybinds.Legendary?.GetAssignedKeys()[0] ?? "UNBOUND"} To unleash a massive tornado at your cursor!\n[c/07EBF2:While holding Aero Scimitar gain increased movement speed]\nIf [c/07EBF2:Tier 2] Every third attack will launch a giant tornado\n[c/07EBF2:Legendary Armament]"));
        }

    }
    
}
