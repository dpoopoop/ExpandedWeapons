using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class HellJavelin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("4 duration damage");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 60;
			item.knockBack = 4f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 28;
			item.useTime = 28;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Orange;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 300);
			item.shoot = ModContent.ProjectileType<HellJavelinProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(175, 15);
            recipe.AddIngredient(173, 20);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}