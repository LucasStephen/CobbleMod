using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class HomingBall : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 30;
           // projectile.shoot = mod.ProjectileType("SwordCut"); ;
        }

		public override void AI()
		{
            projectile.light = 0.9f; //Lights up the whole room
            if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            

					projectile.velocity.X = oldVelocity.X;

					projectile.velocity.Y = oldVelocity.Y;

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
            var velMult = 20;
            p.position.X = (float)target.position.X + (float)(projectile.velocity.X * velMult);
            p.position.Y = (float)target.position.Y + (float)(projectile.velocity.Y * velMult);
            projectile.ai[0] += 0.1f;
			projectile.velocity *= 0.75f;
            var projStartX = projectile.Center.X - (float)(projectile.velocity.X * velMult);
            var projStartY = projectile.Center.Y - (float)(projectile.velocity.Y * velMult);
            var projEndX = projectile.Center.X + (float)(projectile.velocity.X * velMult);
            var projEndY = projectile.Center.Y + (float)(projectile.velocity.Y * velMult);

            Projectile.NewProjectile(projStartX, projStartY, projEndX-projStartX, projEndY-projStartY, mod.ProjectileType("SwordCut"), damage*4, knockback, Main.myPlayer, 0f, 0f); //Spawning a projectile
        }
	}
}