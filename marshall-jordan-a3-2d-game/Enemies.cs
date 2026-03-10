using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Enemies
    {
        public Texture2D enemy;
        public Vector2 gravity = new Vector2(0, -150);
        public Vector2 velocity;
        public Vector2 enemyPosition;

        public Vector2[] enemySpawnPosition =
            [new Vector2(15, 670),
            new Vector2(101, 670),
            new Vector2(187, 670),
            new Vector2(273, 670),
            new Vector2(359, 670),
            new Vector2(445, 670),
            new Vector2(531, 670),
            ];

        public void EnemyLoad()
        {
            for (int i = 0; i < enemySpawnPosition.Length; i++)
            {
                Graphics.Draw(enemy, enemySpawnPosition[i]);
                enemyPosition += enemySpawnPosition[i] += gravity * Time.DeltaTime;
            }
        }
    }
}
