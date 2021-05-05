using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Buffs;

namespace ExpandedWeapons.Items.Magic
{
	public class LeafSpreader : ModItem
	{
		public int leafCooldown;
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"'Sometimes shoots a crystal leaf that does more damage
'Now this is the REAL bullet hell'");
		}

		public override void SetDefaults() {
			item.damage = 40; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.magic = true; // sets the damage type to ranged
			item.width = 32; // hitbox width of the item
			item.height = 24; // hitbox height of the item
			item.useTime = 7; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 7; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 1500);
			item.rare = ItemRarityID.Cyan; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item65; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 206;
			item.shootSpeed = 18f; // the speed of the projectile (measured in pixels per frame)
			item.mana = 5;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
		
			int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 30 degree spread.
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			leafCooldown += 1;
			if (leafCooldown >= 10)
			{
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, 227, damage * 3, knockBack, player.whoAmI);
			leafCooldown = 0;
			}
			return true;
		
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeafBlower, 1);
            recipe.AddIngredient(ItemID.BubbleGun, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}