using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class NebulaEmblem : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases magic damage by 15%"
			+
			"\nDecreases mana cost by 8%"
			+
			"\nIncreases pickup range of mana stars"
			+
			"\nAutomatically uses mana potions when needed");
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
			player.magicDamage += 0.15f;
			player.manaFlower = true;
			player.manaMagnet = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2220, 1);
            recipe.AddIngredient(555, 1);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}