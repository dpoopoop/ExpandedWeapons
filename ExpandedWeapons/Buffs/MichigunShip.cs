using Terraria;
using Terraria.ModLoader;

namespace ExpandedWeapons.Buffs
{
	public class MichigunShip : ModBuff
	{
		static float stable_y = -0.0001f;
		
		public override void SetDefaults() {
			DisplayName.SetDefault("Michigun Ship Mount");
			Description.SetDefault("Perfect for straight flying");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.mount.SetMount(ModContent.MountType<Items.Others.MountMichi>(), player);
			player.allDamage += 0.2f;
			player.endurance += 0.1f;
			player.buffTime[buffIndex] = 10;
			player.noFallDmg = true;
            player.mount._flyTime = 100;
			
			float v = player.velocity.X;
            if (v > 100) v = 100;
            if (v < -100) v = -100;
            if (v > 0 && v < 5) v -= .1f;
            if (v < 0 && v > -5) v += .1f;
            if (v < .5 && v > -.5) v = 0;
            player.velocity.X = v;

            v = player.velocity.Y;
            if (v > 7) v += .1f;
            if (v > 10) v = 10;
            if (v < -10) v = -10;
            if (v != 0 && v > stable_y && v < 5) v -= .1f;
            if (v != 0 && v < stable_y && v > -5) v += .1f;
            if (v != 0 && v < (stable_y + 0.5f) && v > (stable_y - 0.5f)) v = stable_y;
            player.velocity.Y = v;
		}
	}
}