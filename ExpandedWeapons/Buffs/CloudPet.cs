using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles.Minions;

namespace ExpandedWeapons.Buffs
{
	public class CloudPet : ModBuff
	{
		public override void SetDefaults()
		{
			Description.SetDefault("The cloud defender will protect you");
			DisplayName.SetDefault("Cloud");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ExpandedPlayer>().cloudPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("CloudDefender")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("CloudDefender"), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}