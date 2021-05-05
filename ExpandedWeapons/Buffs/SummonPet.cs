using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
	public class SummonPet : ModBuff
	{
		public override void SetDefaults()
		{
			Description.SetDefault("Michigun will protect you");
			DisplayName.SetDefault("Michigun");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			canBeCleared = false;
			if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Minions.MichigunSummon>()] > 0) {
				player.buffTime[buffIndex] = 18000;
			}
			else {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}