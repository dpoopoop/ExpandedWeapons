using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;
using ExpandedWeapons.Items.Others;
using ExpandedWeapons.Projectiles;
//Main.PlaySound(SoundID.DD2_BetsyScream);

namespace ExpandedWeapons.NPCs
{

    public class BullethellNimbus : ModNPC
    {
        
        private int ai;
        private int shootTimer = 0;
        private bool fastSpeed = false;
        private int dashCounter = 0;
        private double counting;
        

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bullethell Nimbus");
        }

        public override void SetDefaults()
        {
        npc.width = 52;
        npc.height = 32;
        npc.aiStyle = -1; //74
        if (NPC.downedGolemBoss)
        {
            npc.damage = 50;
            npc.lifeMax = 2100;
        }
        else
        {
            npc.damage = 30;
            npc.lifeMax = 700;
        }
        npc.defense = 20;
        npc.knockBackResist = 0f;

        npc.value = 50;

        npc.lavaImmune = true;
        npc.noTileCollide = true;
        npc.noGravity = true;

        npc.HitSound = SoundID.NPCHit30;
        npc.DeathSound = SoundID.DD2_KoboldExplosion;
        } 
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override void AI()
        {
            var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 4f, 4f, 100, default, 1.5f);
			dust.noGravity = true;
			dust.velocity /= 2f;

            Player player = Main.player[npc.target];
            npc.TargetClosest(false);
            Vector2 target = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;

            
            npc.netAlways = true;

            //despawn
            if(npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.direction = 1;
                npc.velocity.Y = npc.velocity.Y - 0.1f;
                if(npc.timeLeft > 20)
                {
                    npc.timeLeft = 20;
                    return;
                }
            }
            ai++;
            //movement
            npc.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if((double)npc.ai[0] < 72) //moving
            {
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
                int damage = npc.damage;
                if((double)npc.ai[0] == 30)
                {
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 8, 0, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -8, 0, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 8, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, -8, 128, damage, 0f, Main.myPlayer);
                }
                if((double)npc.ai[0] == 60)
                {
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 5, 5, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -5, 5, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, -5, -5, 128, damage, 0f, Main.myPlayer);
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 5, -5, 128, damage, 0f, Main.myPlayer);
                }
            }
            if ((double)npc.ai[0] >= 70.0)
            {
                ai = 0;
                npc.alpha = 0;
                fastSpeed = false;
            }
            }

        public override void OnHitPlayer(Player target, int damage, bool crit)                
        {
            //target.AddBuff(36, 5 * 60); debuffs?
        }
        private void MoveTowards(NPC npc, Vector2 playerTarget, float speed, float turnResistance)
        {
            var move = playerTarget - npc.Center;
            float length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
            length = move.Length();
            if(length > speed)
            {
                move *= speed / length;
            }
            npc.velocity = move;
        }
        public override void NPCLoot()
        {
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 5f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -5f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 3f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -3f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -3f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 2f, 2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -2f, -2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 2f, -2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -2f, 2f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 1f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, 1f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -1f, 0f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0f, -1f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0.5f, 0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -0.5f, -0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 0.5f, -0.5f, 100, default, 3f);
            Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, -0.5f, 0.5f, 100, default, 3f);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return !spawnInfo.playerSafe && ExpandedNPCWorld.DownedCloudBoss && spawnInfo.player.ZoneRain ? SpawnCondition.OverworldNightMonster.Chance * 0.175f : 0f;
		}
    }
}