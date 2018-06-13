using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CobbleMod.Projectiles
{
	public class KillingIntent : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide=true;
			projectile.penetrate = 1;
			projectile.timeLeft = 400;
			projectile.light = 0.75f;
			projectile.extraUpdates = 1;
			projectile.ignoreWater = true;
            projectile.ai[1] = 0;
		}
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (projectile.ai[1] > 20000)
                {
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
                            shootToX *= distance;
                            shootToY *= distance;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                        }
                    }
                }
                else
                {
                    projectile.ai[1] += 1;
                } 
            }
        }
		
		public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height); //makes dust based on tile
            Main.PlaySound(SoundID.Item10, projectile.position); //plays impact sound
        }
		
		 public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (target.life <= 0)
            {
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, r.Next(-3,3), r.Next(-3, 3), mod.ProjectileType("KillingIntent"), damage * 2, 0, Main.myPlayer, 0f, 0f); //Spawning a projectile
                }
            }
            Player p = Main.player[projectile.owner];
            int healingAmount = damage/30; 
            p.statLife +=healingAmount;
            p.HealEffect(healingAmount, true);
        } 
	}
}
	