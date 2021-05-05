using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExpandedWeapons.Projectiles.Minions
{
	public class MinionBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Minion Beam");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(88);
			aiType = 88;
			projectile.melee = true;
			projectile.timeLeft = 600;
			projectile.width = 8;
			projectile.height = 8;
			projectile.extraUpdates = 2;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
		}
		public override bool PreKill(int timeLeft) {
			projectile.type = 88;
			return true;
		}
	}
}