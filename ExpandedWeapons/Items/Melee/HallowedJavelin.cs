using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class HallowedJavelin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("7 duration damage");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 15f;
			item.damage = 100;
			item.knockBack = 5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Pink;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 800);
			item.shoot = ModContent.ProjectileType<HallowedJavelinProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1225, 10);
            recipe.AddIngredient(520, 10);
			recipe.AddIngredient(521, 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}