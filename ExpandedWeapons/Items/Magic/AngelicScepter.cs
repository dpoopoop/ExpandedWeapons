using ExpandedWeapons.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Magic
{
	public class AngelicScepter : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Shoots bombs with flappy wings'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 150;
			item.magic = true;
			item.mana = 20;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = Item.sellPrice(silver: 1800);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item29;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<AngelBomb>(); //AngelBomb
			item.shootSpeed = 8f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1296, 1);
			recipe.AddIngredient(493, 1);
			recipe.AddIngredient(1516, 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}