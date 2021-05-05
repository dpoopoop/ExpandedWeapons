using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class MichigunMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases melee damage and speed by 10%"
			+
			"\nIncreases melee critical strike chance by 10%"
			+
			"\nIncreases max life by 60"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 45;
		}
		public override void UpdateEquip(Player player) {
			player.meleeDamage += 0.1f;
			player.meleeSpeed += 0.1f;
			player.meleeCrit += 10;
			player.statLifeMax2 += 60;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MichigunSuit>() && legs.type == ModContent.ItemType<MichigunLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Attacks inflict the pointy debuff"
			+ "\nIncreases melee damage by 10%"
			+ "\nIncreases immunity frames";
			player.ammoCost75 = true;
			player.rangedDamage += 0.1f;
			player.longInvince = true;
			player.GetModPlayer<ExpandedPlayer>().attackPointy = true;
		}
	}
}
