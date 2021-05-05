using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class ShootingStar : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'This is an awesome lightshow'");
		}

		public override void SetDefaults() {
			item.damage = 100; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 40; // hitbox width of the item
			item.height = 28; // hitbox height of the item
			item.useTime = 36; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 36; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 2400);
			item.rare = ItemRarityID.Yellow; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item38; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<Sniperstar>();
			item.shootSpeed = 32f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.FallenStar; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
			item.crit = 16;
		}
		public override void HoldItem(Player player)
        {
            foreach(Projectile projectile in Main.projectile)
            {
                Vector2 position = projectile.position + new Vector2(2, -4);
                if (projectile.active && projectile.owner == player.whoAmI && projectile.type == ModContent.ProjectileType<Sniperstar>())
                {
                    Gore gore = Main.gore[Gore.NewGore(position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f)];
                    gore.velocity.Y += 2;
                    for (int i = 0; i < 2; i++)
                    {
                        Dust dust = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, 57 + Main.rand.Next(2), projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 150, default(Color), 0.8f)];
                        dust.velocity *= Main.rand.NextFloatDirection() * 0.5f;
                    }
                }
            }
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1254, 1);
			recipe.AddIngredient(75, 20);
			recipe.AddIngredient(324, 1);
			recipe.AddIngredient(549, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
