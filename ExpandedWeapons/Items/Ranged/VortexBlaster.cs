using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class VortexBlaster : ModItem
	{
		public int vortexCooldown;

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'I didn't beat you, i blast you'");
		}

		public override void SetDefaults() {
			item.damage = 45; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 36; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useAnimation = 24;
			item.useTime = 24;
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 8f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 2600);
			item.rare = ItemRarityID.Red; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item38; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10;
			item.shootSpeed = 20f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.Ranged.CombatShotgun>(), 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 20);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 6 + Main.rand.Next(3); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			vortexCooldown += 10;
			if (vortexCooldown >= 30)
			{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 616, damage, knockBack, player.whoAmI);
			vortexCooldown = 0;
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-15, 0);
		}

	}
}
