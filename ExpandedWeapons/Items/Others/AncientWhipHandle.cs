using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class AncientWhipHandle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 15%"
			+
			"\nIncreases summon damage by 15%"
			+
			"\nIncreases the knockback of minions and whips"
			+
			"\nAttacks inflict venom");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(silver: 500);
			item.rare = ItemRarityID.Yellow;
			item.accessory = true;
		}
		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.meleeSpeed += 0.15f;
			player.minionDamage += 0.15f;
			player.minionKB += 2;
			player.GetModPlayer<ExpandedPlayer>().VenomMelee = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FrozenWhipHandle>(), 1);
            recipe.AddIngredient(1167, 1);
			recipe.AddIngredient(2607, 20);
            recipe.AddTile(114);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}