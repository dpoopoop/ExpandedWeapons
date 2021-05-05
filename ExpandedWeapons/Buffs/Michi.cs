using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
    public class Michi : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Michigun's Ship");
			Description.SetDefault("Michigun will destroy the enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex) {
		}
	}
}