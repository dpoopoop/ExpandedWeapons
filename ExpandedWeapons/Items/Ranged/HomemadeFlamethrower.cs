using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Items.Ranged
{
	// Flamethrowers have some special characteristics, such as shooting several projectiles in one click, and only consuming ammo on the first projectile
	// The most important characteristics, however, are explained in the FlamethrowerProjectile code.
	public class HomemadeFlamethrower : ModItem
	{
		public override void SetStaticDefaults(){
			Tooltip.SetDefault(@"Shoots a spread of flames.
'The stylist made this weapon to defend from the deadly monsters'");
		}

		public override void SetDefaults()
		{
			item.damage = 7; // The item's damage.
			item.ranged = true;
			item.width = 50;
			item.height = 18;
			item.useTime = 8;
			item.useAnimation = 24; 
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; // So the item's animation doesn't do damage
			item.knockBack = 0; // A high knockback. Vanilla Flamethrower uses 0.3f for a weak knockback.
			item.value = Item.sellPrice(silver: 150);
			item.rare = ItemRarityID.Green; // Sets the item's rarity.
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RegularFlames>();
			item.shootSpeed = 4.5f; // How fast the flames will travel. Vanilla Flamethrower uses 7f and consequentially has less reach. item.shootSpeed and projectile.timeLeft together control the range.
			item.useAmmo = AmmoID.Gel; // Makes the weapon use up Gel as ammo
		}
		public override bool ConsumeAmmo(Player player)
		{
			// To make this item only consume ammo during the first jet, we check to make sure the animation just started. ConsumeAmmo is called 5 times because of item.useTime and item.useAnimation values in SetDefaults above.
			return player.itemAnimation >= player.itemAnimationMax - 8; //set to usetime
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 32f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}
	}
}