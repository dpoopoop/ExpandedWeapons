using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
	public class ImpostorCooldown : ModBuff
	{
		public override void SetDefaults()
		{
			Description.SetDefault("Wait until your next attack");
			DisplayName.SetDefault("Impostor Cooldown");
			Main.buffNoTimeDisplay[Type] = false;
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;

		}

		public override void Update(Player player, ref int buffIndex)
		{
			canBeCleared = false;
		}
	}
}