using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class FrozenWhipHandle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 10%"
			+
			"\nIncreases summon damage by 10%"
			+
			"\nAttacks inflict frostburn");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(silver: 200);
			item.rare = ItemRarityID.LightRed;
			item.accessory = true;
		}
		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeSpeed += 0.1f;
			player.minionDamage += 0.1f;
			player.GetModPlayer<ExpandedPlayer>().FrostBurnMelee = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ReinforcedWhipHandle>(), 1);
            recipe.AddIngredient(2161, 1);
			recipe.AddIngredient(2998, 1);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}