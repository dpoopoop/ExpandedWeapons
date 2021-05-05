using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class MichigunHeadgear : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases summon damage by 30%"
			+
			"\nIncreases max minions by 3"
			+
			"\nIncreases max sentries by 1"
			+
			"\nIncreases life regeneration"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 15;
			item.lifeRegen = 3;
		}
		public override void UpdateEquip(Player player) {
			player.minionDamage += 0.3f;
			player.maxTurrets += 1;
			player.maxMinions += 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MichigunSuit>() && legs.type == ModContent.ItemType<MichigunLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Attacks inflict the pointy debuff"
			+ "\nIncreases summon damage by 10%"
			+ "\nIncreases max minions by 2"
			+ "\nIncreases melee speed by 15%"
			+ "\nSummons a michigun that shoots at nearby enemies";
			player.GetModPlayer<ExpandedPlayer>().attackPointy = true;
			player.GetModPlayer<ExpandedPlayer>().summonPet = true;
			player.minionDamage += 0.1f;
			player.meleeSpeed += 0.15f;
			player.maxMinions += 2;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MichigunSummon>()] <= 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.SummonPet>(), 2);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("MichigunSummon"), 250, 0f, Main.myPlayer, 0f, 0f); 
			}
		}
	}
}
