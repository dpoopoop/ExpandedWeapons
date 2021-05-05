using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Body)]
	internal class MichigunSuit : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Michigun Suit");
			Tooltip.SetDefault("Increases all damage by 30%"
			+
			"\nIncreases critical strike chance by 15%"
			+
			"\nIncreases max life by 40"
			+
			"\nIncreases max minions by 1"
			+
			"\nGrants immunity to lava and most debuffs"
			+
			"\n△△△");
		}
		public override void SetDefaults() {
			item.width = 30;
			item.height = 18;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 30;
		}
		public override void UpdateEquip(Player player) {
			player.statLifeMax2 += 40;
			player.allDamage *= 1.3f;
			player.maxMinions += 1;
			player.meleeCrit += 10;
			player.rangedCrit += 10;
			player.magicCrit += 10;
			player.lavaImmune = true;
			player.buffImmune[24] = true;
			player.buffImmune[30] = true;
			player.buffImmune[70] = true;
			player.buffImmune[22] = true;
			player.buffImmune[80] = true;
			player.buffImmune[35] = true;
			player.buffImmune[23] = true;
			player.buffImmune[31] = true;
			player.buffImmune[32] = true;
			player.buffImmune[197] = true;
			player.buffImmune[33] = true;
			player.buffImmune[36] = true;
			player.buffImmune[195] = true;
			player.buffImmune[196] = true;
			player.buffImmune[39] = true;
			player.buffImmune[69] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.buffImmune[156] = true;
			player.buffImmune[164] = true;
			player.buffImmune[163] = true;
			player.buffImmune[144] = true;
			player.buffImmune[145] = true;
			player.buffImmune[67] = true;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms) {
			drawHands = true;
		}
	}
}