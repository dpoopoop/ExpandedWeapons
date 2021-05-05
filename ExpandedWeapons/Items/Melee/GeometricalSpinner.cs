using ExpandedWeapons.Projectiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Melee
{
	public class GeometricalSpinner : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Geometrical Spinner");
			Tooltip.SetDefault(@"Can hit faster than other yoyos
'A very speedy yoyo'");
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 0.75f;
			item.damage = 85;
			item.rare = ItemRarityID.Yellow;
			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 1200);
			item.shoot = ModContent.ProjectileType<GeometricalYoyo>();
		}
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy};
		public override bool AllowPrefix(int pre) {
			if (Array.IndexOf(unwantedPrefixes, pre) > -1) {
				return false;
			}
			return true;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ThrowingCube>(), 1);
			recipe.AddIngredient(3283, 1);
			recipe.AddIngredient(1508, 5);
			recipe.AddIngredient(331, 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}