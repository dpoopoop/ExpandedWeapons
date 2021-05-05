using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons;
using Terraria.Utilities;

namespace ExpandedWeapons.Items.Others
{
	public class MichigunEmblem : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases life regeneration"
			+
			"\nIncreases max life by 50"
			+
			"\nIncreases max mana by 20"
			+
			"\nIncreases all damage by 50%"
			+
			"\nIncreases the max number of minions and sentries by 1"
			+
			"\nIncreases critical chance by 5%"
			+
			"\nSpikes rain when you get hit"
			+
			"\n'Legends never die!'"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 8;
			item.lifeRegen = 1;
			item.accessory = true;
		}
		public override int ChoosePrefix(UnifiedRandom rand) {
			// When the item is given a prefix, only roll the best modifiers for accessories
			return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.statLifeMax2 += 50;
			player.statManaMax2 += 20;
			player.allDamage += 0.5f;
			player.maxTurrets += 1;
			player.maxMinions += 1;
			player.meleeCrit += 5;
			player.rangedCrit += 5;
			player.magicCrit += 5;
			player.GetModPlayer<ExpandedPlayer>().SpikeRain = true;
		}
	}
}