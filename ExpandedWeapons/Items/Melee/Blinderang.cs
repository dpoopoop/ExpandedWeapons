using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class Blinderang : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'A bouncy boomerang'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 14f;
			item.damage = 120;
			item.knockBack = 8f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 15;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Yellow;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 2000);
			item.shoot = ModContent.ProjectileType<BlinderangProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(561, 5);
            recipe.AddIngredient(1508, 25);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}