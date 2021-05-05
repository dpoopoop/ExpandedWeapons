using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class BomberPlane : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault(@"15 duration damage.
'Carpet bombs the area'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 16f;
			item.damage = 130;
			item.knockBack = 6f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 22;
			item.useTime = 22;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Yellow;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 1800);
			item.shoot = ModContent.ProjectileType<BomberPlaneProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PointyPaperPlane>(), 1);
            recipe.AddIngredient(773, 100);
            recipe.AddIngredient(527, 2);
			recipe.AddIngredient(236, 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}