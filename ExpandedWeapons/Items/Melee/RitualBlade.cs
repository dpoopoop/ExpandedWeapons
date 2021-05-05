using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class RitualBlade : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'Magic rituals give it the power to seek towards enemies'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 125;
			item.knockBack = 9f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 12;
			item.useTime = 12;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Cyan;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 1000);
			item.shoot = ModContent.ProjectileType<RitualBladeProj>();
			item.crit = 6;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1122, 1);
            recipe.AddIngredient(2766, 6);
			recipe.AddIngredient(548, 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}