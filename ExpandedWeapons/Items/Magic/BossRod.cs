using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using ExpandedWeapons.Projectiles;
using ExpandedWeapons.Items.Others;

namespace ExpandedWeapons.Items.Magic
{
	class BossRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rod of Claudia");
			Tooltip.SetDefault("'Summons the cloud boss to wreak havoc on where its placed'");
		}

		public override void SetDefaults()
		{
			item.damage = 75;
			item.magic = true;
			item.mana = 15;
			item.width = 64;
			item.height = 64;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 1;
			item.value = Item.sellPrice(silver: 1800);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<BossMoving>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(765, 30);
			recipe.AddIngredient(751, 50);
			recipe.AddIngredient(1244, 1);
			recipe.AddIngredient(ModContent.ItemType<SoulOfCloud>(), 1);
			recipe.AddIngredient(ModContent.ItemType<CloudHandle>(), 1);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<BossCloud>()] >= 1) //max clouds
{
  int projToKill = -1;
  for (int i = 0; i < Main.projectile.Length; i++)
  {
    Projectile proj = Main.projectile[i];
    if (Main.projectile[i].type == ModContent.ProjectileType<BossCloud>() && proj.active && proj.owner == player.whoAmI)
    {
      if (projToKill == -1 || proj.timeLeft < Main.projectile[projToKill].timeLeft)
        projToKill = i;
    }
  }
  if (projToKill != -1)
    Main.projectile[projToKill].Kill();
}
			int index = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<BossMoving>(), damage, knockBack, Main.myPlayer);
			if (Main.projectile[index].modProjectile is BossMoving rainstorm)
			{
				rainstorm.CursorPosition = Main.MouseWorld;
			}
			return false;
		}
	}
}