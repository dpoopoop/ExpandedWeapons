using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class ThunderHammer : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("'LIGHTNING STRIKE!'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 12f;
			item.damage = 125;
			item.knockBack = 10f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 18;
			item.useTime = 18;
			item.width = 32;
			item.height = 32;
			item.rare = ItemRarityID.Red;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 2500);
			item.shoot = ModContent.ProjectileType<ThunderHammerProj>();
			item.crit = 6;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3456, 15);
            recipe.AddIngredient(1513, 1);
			recipe.AddIngredient(1266, 1);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}