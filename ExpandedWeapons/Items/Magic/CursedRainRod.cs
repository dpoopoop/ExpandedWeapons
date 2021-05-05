using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using ExpandedWeapons.Projectiles;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Magic
{
	class CursedRainRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("'Creates a cloud that puts cursed flames on enemies'");
		}

		public override void SetDefaults()
		{
			item.damage = 55;
			item.magic = true;
			item.mana = 12;
			item.width = 64;
			item.height = 64;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 500);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<CursedRainMoving>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(765, 10);
			recipe.AddIngredient(547, 5);
			recipe.AddIngredient(548, 5);
			recipe.AddIngredient(549, 5);
			recipe.AddIngredient(522, 10);
			recipe.AddIngredient(ModContent.ItemType<CloudHandle>(), 1);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<CursedRainCloud>()] >= 2) //max clouds
{
  int projToKill = -1;
  for (int i = 0; i < Main.projectile.Length; i++)
  {
    Projectile proj = Main.projectile[i];
    if (Main.projectile[i].type == ModContent.ProjectileType<CursedRainCloud>() && proj.active && proj.owner == player.whoAmI)
    {
      if (projToKill == -1 || proj.timeLeft < Main.projectile[projToKill].timeLeft)
        projToKill = i;
    }
  }
  if (projToKill != -1)
    Main.projectile[projToKill].Kill();
}
			int index = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<CursedRainMoving>(), damage, knockBack, Main.myPlayer);
			if (Main.projectile[index].modProjectile is CursedRainMoving rainstorm)
			{
				rainstorm.CursorPosition = Main.MouseWorld;
			}
			return false;
		}
	}
}