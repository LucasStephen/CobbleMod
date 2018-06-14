using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
	public class RainbowReaper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rainbow Reaper");
			Tooltip.SetDefault("Double rainbow all the way");
		}
		public override void SetDefaults()
		{
			item.melee = true;
			item.useTurn = true;
			item.damage = 250;
			item.width = 64;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 1000000;
			item.rare = 12;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.shoot = 250;
			item.shootSpeed = 20f;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberProjectiles = 2; // 5 shots
            float rotation = MathHelper.ToRadians(10);//Shoots them in a 10 degree radius. (This is technically 90 degrees because it's 45 degrees up from your cursor and 45 degrees down)
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f; //10 should equal whatever number you had on the previous line
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Vector for spread. Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //Creates a new projectile with our new vector for spread.
            }
            return false; //makes sure it doesn't shoot the projectile again after this
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
