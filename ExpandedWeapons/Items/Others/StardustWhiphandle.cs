using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class StardustWhipHandle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee speed by 20%"
			+
			"\nIncreases summon damage by 15%"
			+
			"\nIncreases the knockback of minions and whips"
			+
			"\nIncreases max number of minions by 1"
			+
			"\nAttacks inflict a very powerful frostburn effect");
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
			player.meleeSpeed += 0.25f;
			player.minionDamage += 0.15f;
			player.minionKB += 2;
			player.maxMinions += 1;
			player.GetModPlayer<ExpandedPlayer>().StardustMelee = true;
		}
		public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AncientWhipHandle>(), 1);
            recipe.AddIngredient(1864, 1);
			recipe.AddIngredient(3459, 10);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}