using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
	public class Tag : ModBuff
	{
		public override void SetDefaults()
		{
			Description.SetDefault("Minion damage increased");
			DisplayName.SetDefault("Summon Tag");
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