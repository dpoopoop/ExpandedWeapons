using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
    public class CoriteKnight : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Corite Knight");
			Description.SetDefault("The corite knight will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MeteorMinion>()] > 0) {
				player.buffTime[buffIndex] = 18000;
				player.GetModPlayer<ExpandedPlayer>().coritePet = true;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}