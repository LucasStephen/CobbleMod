using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Items
{
    public class ShitWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shitty Wand");
            Tooltip.SetDefault("Under Development");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.magic = true;
            item.mana = 0;
            item.rare = 5;
            item.width = 28;
            item.height = 30;
            item.UseSound = SoundID.Item37;
            item.useStyle = 5;
            item.shootSpeed = 100f;
			item.useTime = 10;
            item.useAnimation = 10;
            item.shoot = 280;
			item.autoReuse = true;
            item.value = Item.sellPrice(0, 3, 0, 0);
        }
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberProjectiles = 10; // 5 shots
            float rotation = MathHelper.ToRadians(10);//Shoots them in a 10 degree radius. (This is technically 90 degrees because it's 45 degrees up from your cursor and 45 degrees down)
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 10f; //10 should equal whatever number you had on the previous line
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Vector for spread. Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI); //Creates a new projectile with our new vector for spread.
            }
            return false; //makes sure it doesn't shoot the projectile again after this
        }

    }
}