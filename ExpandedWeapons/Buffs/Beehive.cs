using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;
using ExpandedWeapons;

namespace ExpandedWeapons.Buffs
{
    public class Beehive : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Beehive");
			Description.SetDefault("The beehive is hovering above your head");
			Main.buffNoSave[Type] = true; //does not save after leaving the game.
			Main.buffNoTimeDisplay[Type] = true; //does not display the buff duration.
		}

			public override void Update(Player player, ref int buffIndex) 
			{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.Beehive>()] > 0) {
				player.buffTime[buffIndex] = 18000;
				player.GetModPlayer<ExpandedPlayer>().overheadMinion = true; //activates the overhead minion variable.
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
	}
}
}