using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using ExpandedWeapons.Projectiles;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Magic
{
	class LavaRainRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Creates a big cloud that can directly shoot fireballs at enemies'");
		}

		public override void SetDefaults()
		{
			item.damage = 65;
			item.magic = true;
			item.mana = 13;
			item.width = 64;
			item.height = 64;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 1000);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<LavaRainMoving>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(765, 15);
			recipe.AddIngredient(899, 1);
			recipe.AddIngredient(2766, 5);
			recipe.AddIngredient(175, 20);
			recipe.AddIngredient(ModContent.ItemType<CloudHandle>(), 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<LavaRainCloud>()] >= 2) //max clouds
{
  int projToKill = -1;
  for (int i = 0; i < Main.projectile.Length; i++)
  {
    Projectile proj = Main.projectile[i];
    if (Main.projectile[i].type == ModContent.ProjectileType<LavaRainCloud>() && proj.active && proj.owner == player.whoAmI)
    {
      if (projToKill == -1 || proj.timeLeft < Main.projectile[projToKill].timeLeft)
        projToKill = i;
    }
  }
  if (projToKill != -1)
    Main.projectile[projToKill].Kill();
}
			int index = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<LavaRainMoving>(), damage, knockBack, Main.myPlayer);
			if (Main.projectile[index].modProjectile is LavaRainMoving rainstorm)
			{
				rainstorm.CursorPosition = Main.MouseWorld;
			}
			return false;
		}
	}
}