using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExpandedWeapons.Items.Others
{
    public class MountMichi : ModMountData
    {
        public override void SetDefaults()
        {
            mountData.spawnDust = 91;
            mountData.buff = mod.BuffType("MichigunShip");
            mountData.usesHover = true;
            mountData.heightBoost = 20;
            mountData.fallDamage = 0f;
            mountData.runSpeed = 13f;
            mountData.dashSpeed = 5f;
            mountData.flightTimeMax = 100;
            mountData.fatigueMax = 0;
            mountData.jumpHeight = 3;
            mountData.acceleration = 1f;
            mountData.jumpSpeed = 3f;
            mountData.blockExtraJumps = true;
            mountData.totalFrames = 1;
            int[] array = new int[mountData.totalFrames];
            for (int l = 0; l < array.Length; l++)
            {
                array[l] = 20;
            }
            mountData.playerYOffsets = array;
            mountData.xOffset = 13;
            mountData.bodyFrame = 3;
            mountData.yOffset = 14;
            mountData.playerHeadOffset = 22;
            mountData.standingFrameCount = 1;
            mountData.standingFrameDelay = 24;
            mountData.standingFrameStart = 0;
            mountData.runningFrameCount = 1;
            mountData.runningFrameDelay = 24;
            mountData.runningFrameStart = 0;
            mountData.flyingFrameCount = 1;
            mountData.flyingFrameDelay = 24;
            mountData.flyingFrameStart = 0;
            mountData.inAirFrameCount = 1;
            mountData.inAirFrameDelay = 24;
            mountData.inAirFrameStart = 0;
            mountData.idleFrameCount = 1;
            mountData.idleFrameDelay = 24;
            mountData.idleFrameStart = 0;
            mountData.idleFrameLoop = true;
            mountData.swimFrameCount = mountData.inAirFrameCount;
            mountData.swimFrameDelay = mountData.inAirFrameDelay;
            mountData.swimFrameStart = mountData.inAirFrameStart;
            if (Main.netMode != 2)
            {
                mountData.textureWidth = mountData.backTexture.Width + 20;
                mountData.textureHeight = mountData.backTexture.Height;
            }
        }
        public override void UpdateEffects(Player player)
        {
            int w = this.mountData.textureWidth;
            int h = this.mountData.textureHeight;
            float x = player.position.X - (w / 2) + this.mountData.xOffset + (w * 0.1f);
            float y = player.position.Y + (h / 2) + this.mountData.yOffset - this.mountData.heightBoost + (h * 0.1f);

            if (Math.Abs(player.velocity.X) > 4f || Math.Abs(player.velocity.Y) > 4f)
            {
                Dust.NewDust(new Vector2(x, y), (int)(w * 0.8), (int)(h * 0.8), this.mountData.spawnDust);
            }
        }
    }
}