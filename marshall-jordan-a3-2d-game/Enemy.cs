using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Enemy
    {
        public Texture2D enemy = Graphics.LoadTexture("../../../../assets/graphics/virus.png");
        public Vector2 gravity = new Vector2(0, -200); // move enemy up the screen
        public Vector2 enemyPosition;
        public Vector2[] enemySpawnPosition = [
            new Vector2(15, 670),
            new Vector2(101, 670),
            new Vector2(187, 670),
            new Vector2(273, 670),
            new Vector2(359, 670),
            new Vector2(445, 670),
            new Vector2(531, 670)];

        public Enemy()
        {
            int randIndex = Random.Integer(0, 7);
            enemyPosition = enemySpawnPosition[randIndex];
        }

        public void MoveEnemy()
        {
            enemyPosition += gravity * Time.DeltaTime;
        }

        public void EnemyRespwn()
        {
            int randRespawnIndex = Random.Integer(0, 7);
            enemyPosition = enemySpawnPosition[randRespawnIndex];
        }

        public void EnemyLoad()
        {
            Graphics.Draw(enemy, enemyPosition);
        }
    }
}
