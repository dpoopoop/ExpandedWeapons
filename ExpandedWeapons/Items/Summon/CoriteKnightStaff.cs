using ExpandedWeapons.Projectiles.Minions;
using ExpandedWeapons.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Summon
{
	public class CoriteKnightStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault(@"Summons a corite knight to fight for you.
'Requires 5 minion slots to use and there can only be one'");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 600;
			item.summon = true;
			item.mana = 50;
			item.width = 64;
			item.height = 64;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true;
			item.knockBack = 6;
			item.value = 1500000; 
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.DD2_BetsyScream;
			item.shoot = ModContent.ProjectileType<MeteorMinion>();
			item.buffType = ModContent.BuffType<Buffs.CoriteKnight>();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ExpandedPlayer>().coritePet;
        }
	}
}