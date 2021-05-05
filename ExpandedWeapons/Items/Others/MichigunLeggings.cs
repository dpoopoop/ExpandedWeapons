using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Legs)]
	public class MichigunLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases all damage by 15%"
			+
			"\nIncreases max life by 20"
			+
			"\nIncreases movement speed by 30%"
			+
			"\nIncreases life regeneration"
			+
			"\nGrants immunity to knockback"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 18;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 25;
			item.lifeRegen = 5;
		}

		public override void UpdateEquip(Player player) {
			player.statLifeMax2 += 20;
			player.allDamage *= 1.15f;
			player.moveSpeed += 0.3f;
			player.noKnockback = true;
		}
	}
}

