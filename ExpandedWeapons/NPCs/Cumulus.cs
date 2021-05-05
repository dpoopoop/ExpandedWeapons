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
    [AutoloadBossHead]

    public class Cumulus : ModNPC
    {
        //public override string Texture => "SummonWhips/NPCs/Boss/MeteorBossArcri";
        
        //ai
        private int ai;
        private int shootTimer = 0;
        private bool fastSpeed = false;
        private int dashCounter = 0;

        //anim
        private int frame = 0;
        private double counting;
        

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cumulus");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
        npc.width = 120;
        npc.height = 90;

        npc.boss = true;
        npc.aiStyle = -1; //74
        npc.npcSlots = 5f;
        if (NPC.downedGolemBoss)
        {
            npc.damage = 50;
            npc.lifeMax = 24000;
        }
        else
        {
            npc.damage = 30;
            npc.lifeMax = 8000;
        }
        npc.defense = 20;
        npc.knockBackResist = 0f;

        npc.value = 15000;

        npc.lavaImmune = true;
        npc.noTileCollide = true;
        npc.noGravity = true;

        npc.HitSound = SoundID.NPCHit30;
        npc.DeathSound = SoundID.DD2_KoboldExplosion;
        music = MusicID.OldOnesArmy;
        } 

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale * 0.6);
            npc.damage = (int)(npc.damage * 0.5f);
        } 
        public override void AI()
        {
        if (npc.life < npc.lifeMax / 2)
        {
            npc.color = Color.Gray;
        }
            var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, 91, 4f, 4f, 100, default, 1.5f);
			dust.noGravity = true;
			dust.velocity /= 2f;

            Player player = Main.player[npc.target];
            npc.TargetClosest(false);
            Vector2 target = npc.HasPlayerTarget ? player.Center + new Vector2(300f, 0f) : Main.npc[npc.target].Center;

            
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
            if((double)npc.ai[0] < 300) //moving
            {
                frame = 1;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
            } else if((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 600) //dashing
            {
                dashCounter++;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                frame = 0;
                //MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                if(npc.life >= npc.lifeMax * 0.5F) 
                {
                    float speed = 10;
                    Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float x = player.position.X + (float)(player.width / 2) - vector.X;
                    float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                    float distance2 = (float)Math.Sqrt(x * x + y * y);
                    float factor = speed / distance2;
                    if (dashCounter == 20)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if (dashCounter == 140)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if (dashCounter == 260)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                }
                else
                {
                    float speed = 15;
                    Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float x = player.position.X + (float)(player.width / 2) - vector.X;
                    float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                    float distance2 = (float)Math.Sqrt(x * x + y * y);
                    float factor = speed / distance2;
                    if (dashCounter == 20)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if (dashCounter == 105)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if (dashCounter == 190)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if (dashCounter == 280)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                }    
                    if (dashCounter == 298)
                    {
                        dashCounter = 0;
                    }
                npc.netUpdate = true;
            } 
            //shoot attack
            if((double)npc.ai[0] >= 60 && (double)npc.ai[0] <= 280 && !fastSpeed)
            {
                shootTimer++;
              if (shootTimer <= 220)
              {
                  frame = 1;
                  Vector2 position = npc.Center;
                  Vector2 targetPosition = Main.player[npc.target].Center;
                  Vector2 direction = targetPosition - position;
                  direction.Normalize();
                  float speed = 14f;
                  int type = mod.ProjectileType("CloudBolt");
                  int type2 = mod.ProjectileType("Cloud2");
                  int damage = npc.damage / 2;
                  if (shootTimer == 2)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 1 shot
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);

                      } else
                      {
                          //2nd phase = 2 shots
                          Projectile.NewProjectile(position, direction * speed, type2, damage / 3, 0f, Main.myPlayer);
                      }
                  }
                  if (shootTimer == 60)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 1 shot
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);

                      } else
                      {
                          //2nd phase = 2 shots
                          Projectile.NewProjectile(position, direction * speed, type2, damage / 3, 0f, Main.myPlayer);
                      }
                  }
                  if (shootTimer == 115)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 1 shot
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);

                      } else
                      {
                          //2nd phase = 2 shots
                          Projectile.NewProjectile(position, direction * speed, type2, damage / 3, 0f, Main.myPlayer);
                      }
                  }
                  if (shootTimer == 165)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 1 shot
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);

                      } else
                      {
                          //2nd phase = 2 shots
                          Projectile.NewProjectile(position, direction * speed, type2, damage / 3, 0f, Main.myPlayer);
                      }
                  }
                  if (shootTimer == 210)
                  {
                      if(npc.life >= npc.lifeMax * 0.5F) 
                      {
                          //1st phase = 1 shot
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);

                      } else
                      {
                          //2nd phase = 2 shots
                          Projectile.NewProjectile(position, direction * speed, type2, damage / 3, 0f, Main.myPlayer);
                      }
                  }
              }
              else
              {
                  shootTimer = 0;
              }
            }
            if ((double)npc.ai[0] >= 600.0)
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

        public override void FindFrame(int frameHeight)
        {
            if(frame == 0)
            {
                counting += 1.0;
                if(counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if(counting < 16.0)
                {
                  npc.frame.Y = 0;
                }
                else if (counting < 24.0)
                {
                  npc.frame.Y = 0;
                }
                else if (counting < 32.0)
                {
                  npc.frame.Y = 0;
                }
                else 
                {
                    counting = 0.0;
                }
            }
            else if(frame == 1)
            {
                npc.frame.Y = 96;
            }
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
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
    }
}