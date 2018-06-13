using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class TeleBall : ModProjectile
	{
		public override void SetDefaults()
		{
            Player p = Main.player[projectile.owner];
            projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 100;
			projectile.timeLeft = 90;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            //projectile.aiStyle = 0; 
            // projectile.shoot = mod.ProjectileType("SwordCut"); ;
            projectile.ai[1] = 0;
        }

		public override void AI()
		{
            Player p = Main.player[projectile.owner];
            projectile.light = 0.9f; //Lights up the whole room
            
            var shootToX = System.Convert.ToDouble(projectile.position.X - p.Center.X);
            var shootToY = System.Convert.ToDouble(projectile.position.Y - p.Center.Y);
            double dist = System.Math.Sqrt(projectile.position.X * projectile.position.X + projectile.position.Y * projectile.position.Y); //Distance away from the player
            double distance = System.Math.Sqrt(shootToX * shootToX + shootToY * shootToY);
            //projectile.height += System.Convert.ToInt32(.5 * distance);
            //projectile.width += System.Convert.ToInt32(.5 * distance);
            if (distance < 50)
            {
                projectile.rotation = (float)(System.Math.Sign(projectile.position.Y - p.Center.Y) * (System.Math.Acos((double)(projectile.position.X - p.Center.X) / (double)distance)));
            }
            //Factors for calculations
            
            /*Position the player based on where the player is, the Sin/Cos of the angle times the /
            /distance for the desired distance away from the player minus the projectile's width   /
            /and height divided by two so the center of the projectile is at the right place.     */
            
//            projectile.position.X = p.Center.X - (int)(System.Math.Cos(rad) * dist) - projectile.width / 2;
   //         projectile.position.Y = p.Center.Y - (int)(System.Math.Sin(rad) * dist) - projectile.height / 2;

            //Increase the counter/angle in degrees by 1 point, you can change the rate here too, but the orbit may look choppy depending on the value
            projectile.ai[1] += 1f;
        }
        

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.Kill();
			return false;
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			Main.PlaySound(SoundID.Item25, projectile.position);
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            Player p = Main.player[projectile.owner];
            p.statLife += 2;
            if (target.friendly)
            {
                target.life += 10;
                //target.healEffect(10, true);
            }
        }
	}
}