using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class SporeThrower : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault(@"10 duration damage.
'Leaves a spore trail'");
        }
		public override void SetDefaults() {
			// Alter any of these values as you see fit, but you should probably keep useStyle on 1, as well as the noUseGraphic and noMelee bools
			item.shootSpeed = 15f;
			item.damage = 120;
			item.knockBack = 5.5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 24;
			item.useTime = 24;
			item.width = 33;
			item.height = 33;
			item.rare = ItemRarityID.Lime;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;
			item.UseSound = SoundID.Item19;
			item.value = Item.sellPrice(silver: 1500);
			item.shoot = ModContent.ProjectileType<SporeThrowerProj>();
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(331, 15);
            recipe.AddIngredient(1006, 20);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}