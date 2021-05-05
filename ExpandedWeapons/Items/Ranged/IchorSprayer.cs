using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Items.Ranged
{
	// Flamethrowers have some special characteristics, such as shooting several projectiles in one click, and only consuming ammo on the first projectile
	// The most important characteristics, however, are explained in the FlamethrowerProjectile code.
	public class IchorSprayer : ModItem
	{
		public override void SetStaticDefaults(){
			Tooltip.SetDefault(@"Shoots a spread of ichor flames.
'Spray the blood of gods'");
		}

		public override void SetDefaults()
		{
			item.damage = 29; // The item's damage.
			item.ranged = true;
			item.width = 54;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 30; 
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; // So the item's animation doesn't do damage
			item.knockBack = 1; // A high knockback. Vanilla Flamethrower uses 0.3f for a weak knockback.
			item.value = Item.sellPrice(silver: 1200);
			item.rare = ItemRarityID.Pink; // Sets the item's rarity.
			item.UseSound = SoundID.Item34;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<IchorFlames>();
			item.shootSpeed = 6f; // How fast the flames will travel. Vanilla Flamethrower uses 7f and consequentially has less reach. item.shootSpeed and projectile.timeLeft together control the range.
			item.useAmmo = AmmoID.Gel; // Makes the weapon use up Gel as ammo
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(506, 1);
			recipe.AddIngredient(548, 5);
			recipe.AddIngredient(549, 5);
			recipe.AddIngredient(1332, 20);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			// To make this item only consume ammo during the first jet, we check to make sure the animation just started. ConsumeAmmo is called 5 times because of item.useTime and item.useAnimation values in SetDefaults above.
			return player.itemAnimation >= player.itemAnimationMax - 8; //set to usetime
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 54f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
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