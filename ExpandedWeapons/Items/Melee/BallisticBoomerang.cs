using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class BallisticBoomerang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Might as well call it a BOOMerang'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 140;
			item.knockBack = 11.5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 15;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Purple;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 3000);
			item.shoot = ModContent.ProjectileType<BallisticBoomerangProj>();
			item.crit = 11;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Blinderang>(), 1);
            recipe.AddIngredient(3458, 20);
			recipe.AddIngredient(1347, 100);
			recipe.AddIngredient(3467, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}