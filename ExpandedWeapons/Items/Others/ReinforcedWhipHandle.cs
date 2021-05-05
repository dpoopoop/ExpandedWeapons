using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class ReinforcedWhipHandle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 10%"
			+
			"\nIncreases summon damage by 5%");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(silver: 80);
			item.rare = ItemRarityID.Green;
			item.accessory = true;
		}
		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeSpeed += 0.1f;
			player.minionDamage += 0.05f;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(216, 1);
            recipe.AddIngredient(22, 20);
            recipe.anyIronBar = true;
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}