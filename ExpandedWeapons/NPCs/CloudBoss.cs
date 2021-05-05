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

    public class CloudBoss : ModNPC
    {
        //public override string Texture => "SummonWhips/NPCs/Boss/MeteorBossArcri";
        
        //ai
        private int ai;
        private int attackTimer = 0;
        private int normaltimer = 0;
        private int normaltimer2  = 0;
        private int chasetimer = 0;
        private int chasetimer2  = 0;
        private bool fastSpeed = false;
        private int messageProgress = 0;
        private int state;
        private int state2;
        private int chasestate;
        private int chasestate2;

        private bool stunned;
        private int stunnedTimer;

        //anim
        private int frame = 0;
        private double counting;
        

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Claudia the Cloud");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
        npc.width = 250;
        npc.height = 120;

        npc.boss = true;
        npc.aiStyle = -1; //74
        npc.npcSlots = 5f;
        if (NPC.downedGolemBoss)
        {
            npc.lifeMax = 48000;
            npc.damage = 50;
        }
        else
        {
            npc.lifeMax = 16000;
            npc.damage = 20;
        }
        npc.defense = 50;
        npc.knockBackResist =0f;

        npc.value = 150000;

        npc.lavaImmune = true;
        npc.noTileCollide = true;
        npc.noGravity = true;

        npc.HitSound = SoundID.NPCHit30;
        npc.DeathSound = SoundID.DD2_KoboldExplosion;
        music = MusicID.OldOnesArmy;

        bossBag = mod.ItemType("CloudBossBag");
        } 

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * bossLifeScale * 0.6);
            npc.damage = (int)(npc.damage * 0.6f);
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
            npc.TargetClosest(true);
            Vector2 target = npc.HasPlayerTarget ? player.Center + new Vector2(0f, -250f) : Main.npc[npc.target].Center;
            Vector2 chasetarget = npc.HasPlayerTarget ? player.Center : Main.npc[npc.target].Center;
            Vector2 target2 = npc.HasPlayerTarget ? player.Center + new Vector2(300f, 0f) : Main.npc[npc.target].Center;
            #region Boss Talking

        if (NPC.downedGolemBoss)
        {
            if (npc.life <= npc.lifeMax * 0.99F && messageProgress == 0)
        {
        Main.NewText("Oh, you again? Heh, get ready.", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
        }
        else
        {
            if (npc.life <= npc.lifeMax * 0.99F && messageProgress == 0)
        {
        Main.NewText("Lets get started with this fight.", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
        }
        if (npc.life <= npc.lifeMax * 0.7F && messageProgress == 1)
        {
        Main.NewText("You think you're strong?", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
            if (npc.life <= npc.lifeMax * 0.5F && messageProgress == 2)
        {
        Main.NewText("Go ahead my little one, do whatever you want!", (byte)180, (byte)240, (byte)160, false);
        NPC.NewNPC((int)player.position.X, (int)player.position.Y + 160, mod.NPCType("Cumulus"));
        messageProgress += 1;
        }
        if (npc.life <= npc.lifeMax * 0.3F && messageProgress == 3)
        {
        Main.NewText("How are you still alive?", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
        if (npc.life <= npc.lifeMax * 0.15F && messageProgress == 4)
        {
        Main.NewText("You are simply insane!", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
        if (npc.life <= npc.lifeMax * 0.05F && messageProgress == 5)
        {
        Main.NewText("I guess its over...", (byte)180, (byte)240, (byte)160, false);
        messageProgress += 1;
        }
        #endregion
            
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
            //stunned
            if(stunned)
            {
                npc.velocity.X = 0.0f;
                npc.velocity.Y = 0.0f;

                stunnedTimer++;

                if(stunnedTimer >= 300)
                {
                    stunned = false;
                    stunnedTimer = 0;
                }
            }
            ai++;
            //0-300 = normal
            //300-350 = stunned
            //350-800 = fast
            //when it reaches 800, goes back to normal
            //movement
            npc.ai[0] = (float)ai * 1f;
            int distance = (int)Vector2.Distance(target, npc.Center);
            if (npc.life >= npc.lifeMax * 0.99F)
            {
            MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
            npc.netUpdate = true;
            }
            else
            {
            if (NPC.AnyNPCs(ModContent.NPCType<Cumulus>()))
            {
                npc.dontTakeDamage = true;
                frame = 0;
                npc.defense = 9999;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
                attackTimer++;
              if (attackTimer <= 250)
              {
                  frame = 0;
                  Vector2 position = npc.Center;
                  Vector2 targetPosition = Main.player[npc.target].Center;
                  Vector2 direction = targetPosition - position;
                  direction.Normalize();
                  float speed = 10f;
                  int type = mod.ProjectileType("CloudBlast"); //128
                  int damage = npc.damage * 2;
                  if (attackTimer == 2)
                  {
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                  }  
                  if (attackTimer == 60)
                  {
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                  }
                  if (attackTimer == 120)
                  {
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                  }
                  if (attackTimer == 180)
                  {
                          Projectile.NewProjectile(position, direction * speed, type, damage, 0f, Main.myPlayer);
                  }
                  if (attackTimer == 240)
                  {
                      //nothing
                  }
              }
              else
              {
                  attackTimer = 0;
              }
            }
            else
            {
            if((double)npc.ai[0] < 300) //Regular Attacks
            {
                frame = 0;
                npc.dontTakeDamage = false;
                npc.defense = 50;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
                if (npc.life <= npc.lifeMax * 0.5F) //2nd phase
                {
                    MoveTowards(npc, target2, (float)(distance > 300 ? 13f : 7f), 30f);
                    if (normaltimer2 == 0)
                    {
                    state2 = Main.rand.Next(2);
                    }
                    normaltimer2++;
                Vector2 bolt2position = npc.Center;
                Vector2 bolt2targetPosition = Main.player[npc.target].Center;
                Vector2 bolt2direction = bolt2targetPosition - bolt2position;
                bolt2direction.Normalize();
                float bolt2speed = 10f;
                int bolt2type = mod.ProjectileType("CloudTrailer"); //128
                int bolt1type = mod.ProjectileType("PrebossTrailer");
                int bolt2damage = npc.damage;
                int sweepdamage = npc.damage / 2;
                    if (state2 == 0)
                    {
                        if (NPC.downedGolemBoss)
                    {
                        if((double)npc.ai[0] == 30)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt2type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 90)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt2type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 150)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt2type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 210)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt2type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 298)
                    {
                    normaltimer2 = 0;
                    }
                    }
                    else
                    {
                       if((double)npc.ai[0] == 60)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt1type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 120)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt1type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 180)
                    {
                        Main.PlaySound(2, -1, -1, 96, 1f, +0f);
                        Projectile.NewProjectile(bolt2position, bolt2direction * bolt2speed, bolt1type, bolt2damage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 298)
                    {
                    normaltimer2 = 0;
                    } 
                    }
                    }
                    if (state2 == 1)
                    {
                        if (NPC.downedGolemBoss)
                    {
                    if((double)npc.ai[0] == 30)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 90)
                    {
                        Projectile.NewProjectile(player.position.X -50, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +50, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -250, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +250, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -350, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +350, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -550, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +550, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 150)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 210)
                    {
                        Projectile.NewProjectile(player.position.X -50, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +50, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -250, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +250, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -350, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +350, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -550, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +550, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 270)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +100, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +200, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +400, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +500, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 298)
                    {
                    normaltimer2 = 0;
                    }
                    }
                    else
                    {
                        if((double)npc.ai[0] == 60)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 140)
                    {
                        Projectile.NewProjectile(player.position.X -75, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +75, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -225, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +225, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -375, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +375, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -525, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +525, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 220)
                    {
                        Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +150, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +300, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +450, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X -600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"), sweepdamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(player.position.X +600, player.position.Y - 480, 0, 8, mod.ProjectileType("CloudBolt"),sweepdamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 298)
                    {
                    normaltimer2 = 0;
                    }
                    }
                    }
                }
                else //1st phase
                {
                if (normaltimer == 0)
    {
        state = Main.rand.Next(2);
    }
                Vector2 boltposition = npc.Center;
                Vector2 bolttargetPosition = Main.player[npc.target].Center;
                Vector2 boltdirection = bolttargetPosition - boltposition;
                boltdirection.Normalize();
                float boltspeed = 7f;
                int bolttype = mod.ProjectileType("CloudThunder"); //128
                int boltdamage = npc.damage;
    normaltimer++;
    if (state == 0)
    {
        int laserdamage = npc.damage * 2;
        if((double)npc.ai[0] == 60)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 70)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 80)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 90)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 100)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 110)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 120)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 130)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 140)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 150)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 160)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 170)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 180)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 190)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 200)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 210)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 220)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y - 480, 0, 10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 230)
        {
             Projectile.NewProjectile(player.position.X, player.position.Y + 480, 0, -10, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 240)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 250)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 260)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 270)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 280)
        {
             Projectile.NewProjectile(player.position.X -600, player.position.Y, 10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 290)
        {
             Projectile.NewProjectile(player.position.X +600, player.position.Y, -10, 0, mod.ProjectileType("CloudBlast"), laserdamage, 0f, Main.myPlayer);
             Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 298)
        {
        normaltimer = 0;
        }
    }
    if (state == 1)
    {
        if((double)npc.ai[0] == 30)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 60)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
        
        }
        if((double)npc.ai[0] == 90)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 120)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
        }
        if((double)npc.ai[0] == 150)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 180)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
        }
        if((double)npc.ai[0] == 210)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        }
        if((double)npc.ai[0] == 240)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), boltdamage / 2, 0f, Main.myPlayer);
        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
        }
        if((double)npc.ai[0] == 270)
        {
        Projectile.NewProjectile(boltposition, boltdirection * boltspeed, bolttype, boltdamage, 0f, Main.myPlayer);
        } 
        if((double)npc.ai[0] == 298)
        {
        normaltimer = 0;
        }
    }
                }
            } else if((double)npc.ai[0] >= 300 && (double)npc.ai[0] < 600.0) //Stunned Attacks
            {
                frame = 1;
                npc.dontTakeDamage = false;
                stunned = true;
                npc.defense = 100;
                MoveTowards(npc, target, (float)(distance > 300 ? 13f : 7f), 30f);
                npc.netUpdate = true;
                if (npc.life <= npc.lifeMax * 0.5F) //2nd phase
                {
                    int spiraldamage2 = npc.damage / 2;
                    if((double)npc.ai[0] == 360)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 8, 8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -8, 8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -8, -8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 8, -8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 420)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, -10, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 10, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 480)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 8, 8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -8, 8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -8, -8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 8, -8, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 540)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, -10, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 10, mod.ProjectileType("CloudBomb"), spiraldamage2, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                }
                else //1st phase
                {
                    int spiraldamage = npc.damage / 2;
                        if((double)npc.ai[0] == 360)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 420)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 480)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                    if((double)npc.ai[0] == 540)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, -10, 0, mod.ProjectileType("CloudBomb"), spiraldamage, 0f, Main.myPlayer);
                        Main.PlaySound(2, -1, -1, 95, 1f, +0f);
                    }
                }
            } 
            else if((double)npc.ai[0] >= 600.0) //Chasing Attacks
            {
                frame = 1;
                stunned = false;
                npc.dontTakeDamage = false;
                npc.defense = 50;
                if (!fastSpeed)
                {
                    fastSpeed = true;
                }
                if (npc.life <= npc.lifeMax * 0.49F) //2nd phase
                {
                    if (chasetimer2 == 0)
                    {
                    chasestate2 = Main.rand.Next(2);
                    }
                    chasetimer2++;
                    if (chasestate2 == 0) //dash
                    {
                    float speed = 10;
                    Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float x = player.position.X + (float)(player.width / 2) - vector.X;
                    float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                    float distance2 = (float)Math.Sqrt(x * x + y * y);
                    float factor = speed / distance2;
                    int traildamage = npc.damage;
                        if((double)npc.ai[0] == 620)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 640)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 660)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 680)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 700)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 720)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 740)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 760)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 780)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 800)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 820)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 840)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 860)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0.6f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                    if((double)npc.ai[0] == 880)
                    {
                        Projectile.NewProjectile(npc.position.X, npc.position.Y, 0, 0, mod.ProjectileType("DashTrail"), traildamage, 0f, Main.myPlayer);
                    }
                        if((double)npc.ai[0] == 898)
                    {
                        chasetimer = 0;
                    }
                    }
                    if (chasestate2 == 1) //summon
                    {
                        MoveTowards(npc, chasetarget, (float)(distance > 300 ? 13f : 7f), 30f);
                        if((double)npc.ai[0] == 660)
                    {
                        if (NPC.downedGolemBoss)
                    {
                        NPC.NewNPC((int)player.position.X + 160, (int)player.position.Y, mod.NPCType("BullethellNimbus"));
                        NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y, mod.NPCType("BullethellNimbus"));
                    }
                    else
                    {
                        NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y, mod.NPCType("BullethellNimbus"));
                    }
                    }
                        if((double)npc.ai[0] == 898)
                    {
                        chasetimer = 0;
                    }
                    }
                }
                else //1st phase
                {
                    if (chasetimer == 0)
                    {
                    chasestate = Main.rand.Next(2);
                    }
                    chasetimer++;
                    if (chasestate == 0) //dash
                    {
                    float speed = 10;
                    Vector2 vector = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float x = player.position.X + (float)(player.width / 2) - vector.X;
                    float y = player.position.Y + (float)(player.height / 2) - vector.Y;
                    float distance2 = (float)Math.Sqrt(x * x + y * y);
                    float factor = speed / distance2;
                    if((double)npc.ai[0] == 620)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if((double)npc.ai[0] == 740)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                    if((double)npc.ai[0] == 860)
                    {
                    Main.PlaySound(15, -1, -1, 0, 1f, +0f);
                    npc.velocity.X = x * factor;
                    npc.velocity.Y = y * factor;
                    }
                        if((double)npc.ai[0] == 898)
                    {
                        chasetimer = 0;
                    }
                    }
                    if (chasestate == 1) //summon
                    {
                        MoveTowards(npc, chasetarget, (float)(distance > 300 ? 13f : 7f), 30f);
                        if((double)npc.ai[0] == 660)
                    {
                        NPC.NewNPC((int)player.position.X + 160, (int)player.position.Y, mod.NPCType("AggressiveNimbus"));
                        NPC.NewNPC((int)player.position.X - 160, (int)player.position.Y, mod.NPCType("AggressiveNimbus"));
                    }
                        if((double)npc.ai[0] == 898)
                    {
                        chasetimer = 0;
                    }
                    }
                }
            }
            if ((double)npc.ai[0] >= 900.0) //Reset
            {
                ai = 0;
                npc.alpha = 0;
                fastSpeed = false;
            }
            }
            if (NPC.AnyNPCs(ModContent.NPCType<CloudSwarmer>()))
            {
                npc.defense = 9999;
            }
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
                npc.frame.Y = 128;
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

            ExpandedNPCWorld.DownedCloudBoss = true;
            if(Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                if (NPC.downedGolemBoss)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Others.SoulOfCloud>());
                    int echoice = Main.rand.Next(4);
			if (echoice == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Magic.Mordred>());
			}
			else if (echoice == 1) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Summon.GeometricalWhipinator>());
				}
			else if (echoice == 2) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Melee.TwoFacedAgony>());
			}
			else if (echoice == 3) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Ranged.BoltSniper>());
			}
                }

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Items.Others.CloudHandle>());
                
                var dropChooser = new WeightedRandom<int>();
                dropChooser.Add(ItemID.NimbusRod); 
                dropChooser.Add(ItemID.DaedalusStormbow); 
                dropChooser.Add(ItemID.SkyFracture); 
                dropChooser.Add(ItemID.FairyWings); 
                int choice = dropChooser;
                Item.NewItem(npc.getRect(), choice);
                if(Main.rand.Next(100) < 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width,npc.height, ModContent.ItemType<Items.Others.ThreeSpikes>());
                }
                if(Main.rand.Next(100) < 50)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width,npc.height, ItemID.Cloud, Main.rand.Next(10, 30));
                }
                if(Main.rand.Next(100) < 50)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width,npc.height, ItemID.RainCloud, Main.rand.Next(5, 15));
                }
                if (Main.rand.Next(10) == 0)
	            Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Others.CloudBossTrophy>());
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
    }
}