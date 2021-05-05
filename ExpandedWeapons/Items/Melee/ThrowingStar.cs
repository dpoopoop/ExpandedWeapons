using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class ThrowingStar : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("8 duration damage");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 17f;
			item.damage = 110;
			item.knockBack = 5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Pink;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 1000);
			item.shoot = ModContent.ProjectileType<ThrowingStarProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(75, 20);
			recipe.AddIngredient(161, 50);
            recipe.AddIngredient(547, 10);
			recipe.AddIngredient(548, 10);
			recipe.AddIngredient(549, 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}