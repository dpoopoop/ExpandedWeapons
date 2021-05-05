using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles.Minions
{
	public class NebulaBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Nebula Beam");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(88);
			aiType = 88;
			projectile.minion = true;
			projectile.timeLeft = 600;
			projectile.extraUpdates = 10;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 40;
		}
		public override bool PreKill(int timeLeft) {
			projectile.type = 88;
			return true;
		}
	}
}