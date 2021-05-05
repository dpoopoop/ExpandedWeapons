using Terraria;
using Terraria.ModLoader;
using ExpandedWeapons.NPCs;

namespace ExpandedWeapons.Buffs
{
    public class Pointy : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pointy");
            Description.SetDefault("Cut by spikes");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ExpandedGlobalNPC>().michiGun = true;
            var dust = Dust.NewDustDirect(npc.position, 5, 5, 5, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            Dust.NewDustDirect(npc.position, 5, 5, 5, npc.velocity.X * Main.rand.Next(-5, 5), npc.velocity.Y * Main.rand.Next(-5, 5), 100, default, 1f);
            dust.noGravity = true;
        }
    }
}