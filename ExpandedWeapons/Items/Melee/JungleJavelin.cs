using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class JungleJavelin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("3 duration damage");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 10f;
			item.damage = 30;
			item.knockBack = 3.5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 28;
			item.useTime = 28;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Green;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 100);
			item.shoot = ModContent.ProjectileType<JungleJavelinProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(209, 5);
            recipe.AddIngredient(331, 10);
            recipe.AddIngredient(9, 20);
            recipe.anyWood = true;
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}