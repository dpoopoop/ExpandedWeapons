using Terraria;
using Terraria.ModLoader;

namespace ExpandedWeapons.Buffs
{
    public class Pertubator : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pertubator");
            Description.SetDefault("Neon!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage += 0.5f;
        }
    }
}