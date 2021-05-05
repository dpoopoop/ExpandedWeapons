using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class SignalPistol : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Uses flares as ammo");
		}

		public override void SetDefaults() {
			item.damage = 20; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 40; // hitbox width of the item
			item.height = 28; // hitbox height of the item
			item.useTime = 18; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 18; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 6; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 150);
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item11; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10;
			item.shootSpeed = 8f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Flare; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override void HoldItem(Player player)
        {
            foreach(Projectile projectile in Main.projectile)
            {
                Vector2 position = projectile.position + new Vector2(2, -4);
                if (projectile.active && projectile.owner == player.whoAmI && projectile.type == ModContent.ProjectileType<Betterstar>())
                {
                    Gore gore = Main.gore[Gore.NewGore(position, new Vector2(projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f), Main.rand.Next(16, 18), 0.1f)];
                    gore.velocity.Y += 2;
                    for (int i = 0; i < 2; i++)
                    {
                        Dust dust = Main.dust[Dust.NewDust(position, projectile.width, projectile.height, 57 + Main.rand.Next(2), projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 150, default(Color), 0.3f)];
                        dust.velocity *= Main.rand.NextFloatDirection() * 0.5f;
                    }
                }
            }
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(5, 0);
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(930, 1);
			recipe.AddIngredient(22, 10);
			recipe.anyIronBar = true;
			recipe.AddIngredient(318, 5);
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
