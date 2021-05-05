using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class VortexScope : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases ranged damage by 15%"
			+
			"\nIncreases ranged critical strike chance by 10%"
			+
			"\nAllows you to zoom out"
			+
			"\nIncreases arrow damage by 10% and greatly increases arrow speed"
			+
			"\n20% chance to not consume arrows");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Red;
			item.accessory = true;
		}
		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.rangedCrit += 10;
			player.rangedDamage += 0.15f;
			player.scope = true;
			player.magicQuiver = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1858, 1);
            recipe.AddIngredient(1321, 1);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}