using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class MichigunHelmet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases ranged damage by 20%"
			+
			"\nIncreases ranged critical strike chance by 10%"
			+
			"\nIncreases max life by 40"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player) {
			player.rangedDamage += 0.2f;
			player.rangedCrit += 10;
			player.statLifeMax2 += 40;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MichigunSuit>() && legs.type == ModContent.ItemType<MichigunLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Attacks inflict the pointy debuff"
			+ "\nIncreases ranged damage by 10%"
			+ "\n25% chance not to consume ammo";
			player.ammoCost75 = true;
			player.rangedDamage += 0.1f;
			player.GetModPlayer<ExpandedPlayer>().attackPointy = true;
		}
	}
}
