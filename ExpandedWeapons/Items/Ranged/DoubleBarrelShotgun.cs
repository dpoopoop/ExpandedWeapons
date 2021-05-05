using ExpandedWeapons.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace ExpandedWeapons.Items.Ranged
{
	public class DoubleBarrelShotgun : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Shoots in bursts of 2'");
		}

		public override void SetDefaults() {
			item.damage = 15; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.ranged = true; // sets the damage type to ranged
			item.width = 36; // hitbox width of the item
			item.height = 20; // hitbox height of the item
			item.useAnimation = 20;
			item.useTime = 10;
			item.reuseDelay = 30;
			item.useStyle = ItemUseStyleID.HoldingOut; // how you use the item (swinging, holding out, etc)
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = Item.sellPrice(silver: 700);
			item.rare = ItemRarityID.Orange; // the color that the item's name will be in-game
			//item.UseSound = SoundID.Item36; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = 10;
			item.shootSpeed = 14f; // the speed of the projectile (measured in pixels per frame)
			item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Note that this is not an item Id, but just a magic value.
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(3); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
		public override void HoldItem(Player player)
        {
            HoldItemSFX(player, item, 2, 36);
		}
		public static int HoldItemSFXCounter;
        /// <summary>
        /// Allows sounds to be played in time with reuseDelay, with true returned on 1st frame
        /// </summary>
        /// <param name="player"></param>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static bool HoldItemSFX(Player player, Item item, int type, int style)
        {
            bool firstFrame = false;
            if (player.itemAnimation > 0 && HoldItemSFXCounter <= 1)
            {
                HoldItemSFXCounter = item.useAnimation + item.reuseDelay - 1;
                firstFrame = true;
            }
            if (HoldItemSFXCounter > 0)
            {
                int activeVolley = HoldItemSFXCounter - item.reuseDelay;
                if (activeVolley >= 0 && (activeVolley + 1) % item.useTime == 0)
                {
                    Main.PlaySound(type, player.position, style);
                }
                HoldItemSFXCounter--;
            }
            return firstFrame;
        }
	}
}
