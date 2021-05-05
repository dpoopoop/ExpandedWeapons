using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Others
{
public class EndlessStarCanister: ModItem
{
public override void SetDefaults()
{
item.ranged = true;
item.width = 42;
item.height = 32;
item.maxStack = 1;
item.knockBack = 1.5f;
item.value = Item.sellPrice(silver: 2500);
item.rare = 10;
//item.shoot = 12;
//item.shootSpeed = 5f;
item.ammo = AmmoID.FallenStar;
}
public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(75, 420);
			recipe.AddTile(125);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
}
}