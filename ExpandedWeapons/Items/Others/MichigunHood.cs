using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Items.Others
{
	[AutoloadEquip(EquipType.Head)]
	public class MichigunHood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases magic damage by 20%"
			+
			"\nIncreases magic critical strike chance by 10%"
			+
			"\nIncreases max life by 20"
			+
			"\nIncreases max mana by 100"
			+
			"\nReduces mana cost by 20%"
			+
			"\n△△△");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 14;
			item.value = Item.sellPrice(platinum: 1);
			item.rare = ItemRarityID.Purple;
			item.defense = 20;
		}
		public override void UpdateEquip(Player player) {
			player.magicDamage += 0.2f;
			player.magicCrit += 10;
			player.statLifeMax2 += 20;
			player.statManaMax2 += 100;
			player.manaCost = 0.8f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<MichigunSuit>() && legs.type == ModContent.ItemType<MichigunLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Attacks inflict the pointy debuff"
			+ "\nIncreases magic damage by 10%"
			+ "\nSummons a michigun that provides boosts in battle";
			player.GetModPlayer<ExpandedPlayer>().attackPointy = true;
			player.GetModPlayer<ExpandedPlayer>().magicPet = true;
			player.magicDamage += 0.1f;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MichigunMagic>()] <= 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.MagicPet>(), 2);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("MichigunMagic"), 0, 0f, Main.myPlayer, 0f, 0f); 
			}
		}
	}
}
