using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class SolarGauntlet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 20%"
			+
			"\nIncreases melee damage by 20%"
			+
			"\nGrants the yoyo bag effect"
			+
			"\nMelee attacks inflict the daybroken debuff");
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
			player.meleeSpeed += 0.2f;
			player.meleeDamage += 0.2f;
			player.yoyoGlove = true;
			player.yoyoString = true;
			player.counterWeight = 561;
			player.GetModPlayer<ExpandedPlayer>().attackDay = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1343, 1);
            recipe.AddIngredient(3366, 1);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}