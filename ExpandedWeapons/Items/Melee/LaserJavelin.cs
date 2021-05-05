using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class LaserJavelin : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault(@"20 duration damage.
'The javelin shoots lasers at nearby enemies'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 16f;
			item.damage = 130;
			item.knockBack = 6.5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 22;
			item.useTime = 22;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Cyan;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 2000);
			item.shoot = ModContent.ProjectileType<LaserJavelinProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(2882);
            recipe.AddIngredient(502, 30);
            recipe.AddIngredient(2860, 50);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}