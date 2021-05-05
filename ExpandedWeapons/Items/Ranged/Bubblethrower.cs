using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ExpandedWeapons.Projectiles;

namespace ExpandedWeapons.Items.Ranged
{
	// Flamethrowers have some special characteristics, such as shooting several projectiles in one click, and only consuming ammo on the first projectile
	// The most important characteristics, however, are explained in the FlamethrowerProjectile code.
	public class Bubblethrower : ModItem
	{
		public override void SetStaticDefaults(){
			Tooltip.SetDefault(@"40% chance to not consume ammo.
'Shoots a stream of bubbles'");
		}

		public override void SetDefaults()
		{
			item.damage = 60; // The item's damage.
			item.ranged = true;
			item.width = 86;
			item.height = 32;
			item.useTime = 5;
			item.useAnimation = 10; 
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; // So the item's animation doesn't do damage
			item.knockBack = 2; // A high knockback. Vanilla Flamethrower uses 0.3f for a weak knockback.
			item.value = Item.sellPrice(silver: 2000);
			item.rare = ItemRarityID.Yellow; // Sets the item's rarity.
			item.UseSound = SoundID.Item85;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<BubbleFlames>();
			item.shootSpeed = 8f; // How fast the flames will travel. Vanilla Flamethrower uses 7f and consequentially has less reach. item.shootSpeed and projectile.timeLeft together control the range.
			item.useAmmo = AmmoID.Gel; // Makes the weapon use up Gel as ammo
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(2623, 1);
			recipe.AddIngredient(3261, 20);
			recipe.AddIngredient(547, 15);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool ConsumeAmmo(Player player)
		{
			// To make this item only consume ammo during the first jet, we check to make sure the animation just started. ConsumeAmmo is called 5 times because of item.useTime and item.useAnimation values in SetDefaults above.
			return player.itemAnimation >= player.itemAnimationMax - 5 && Main.rand.NextFloat() >= .40f; //set to usetime
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 74f; //This gets the direction of the flame projectile, makes its length to 1 by normalizing it. It then multiplies it by 54 (the item width) to get the position of the tip of the flamethrower.
			if (Collision.CanHit(position, 6, 6, position + muzzleOffset, 6, 6))
			{
				position += muzzleOffset;
			}
			return true;
        }
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, -7);
		}
	}
}