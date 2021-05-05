using ExpandedWeapons.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ExpandedWeapons.Items.Magic
{
	public class TheSafire : ModItem
	{
		// You can use a vanilla texture for your item by using the format: "Terraria/Item_<Item ID>".
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Safire");
			Tooltip.SetDefault(@"Shoots an inaccurate beam that increases accuracy over time.
'Its a safire, without an eye'");
		}

		public override void SetDefaults()
		{
			// Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
			// For example, this copies sprite size, use style, sell price, and the item being a magic weapon.
			item.CloneDefaults(ItemID.LastPrism);
			item.mana = 5;
			item.damage = 30;
			item.knockBack = 0f;
			item.rare = ItemRarityID.LightPurple;
			item.shoot = ModContent.ProjectileType<SafireHoldout>();
			item.shootSpeed = 30f;
			item.value = Item.sellPrice(gold: 10);
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(177, 15);
			recipe.AddIngredient(502, 15);
			recipe.AddIngredient(38, 10);
			recipe.AddIngredient(520, 10);
            recipe.AddIngredient(549, 5);
			recipe.AddIngredient(548, 5);
			recipe.AddIngredient(547, 5);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		// Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
		public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<SafireHoldout>()] <= 0;
	}
}