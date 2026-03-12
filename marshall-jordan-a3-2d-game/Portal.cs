using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Portal
    {
        public Texture2D portal = Graphics.LoadTexture("../../../../assets/graphics/portal.png");
        public Vector2[] portalPosition =
           [new Vector2(4, 702),
            new Vector2(90, 702),
            new Vector2(176, 702),
            new Vector2(262, 702),
            new Vector2(348, 702),
            new Vector2(434, 702),
            new Vector2(520, 702),
            ];
        public void PortalLoad()
        {         
            for (int i = 0; i < portalPosition.Length; i++)
            {
                Graphics.Draw(portal, portalPosition[i]);
            }
        }

        public void SpawnEnemy()
        {

        }
    }
}
