using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D
{
    public class Player
    {
        Texture2D playerFrame1;
        Texture2D playerFrame2;
        Texture2D playerHurt;

        public void PlayerLoad()
        {
            playerFrame1 = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-robot-game/assets/graphics/robot character1.png");
            playerFrame2 = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-robot-game/assets/graphics/robot character2.png");
            playerHurt = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-robot-game/assets/graphics/robot character hurt1.png");
        }
    }
}
