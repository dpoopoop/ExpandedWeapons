using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class ThrowingCube : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Some geometry needed to throw properly'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 75;
			item.knockBack = 8f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 18;
			item.useTime = 18;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Pink;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 500);
			item.shoot = ModContent.ProjectileType<ThrowingCubeProj>();
			item.crit = 6;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 15);
            recipe.AddIngredient(180, 10);
			recipe.AddIngredient(177, 5);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}