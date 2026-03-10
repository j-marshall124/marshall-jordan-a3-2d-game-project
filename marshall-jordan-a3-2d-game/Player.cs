using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D
{
    public class Player
    {
        public Texture2D playerFrame1;
        public Texture2D playerFrame2;
        public Texture2D playerHurt;

        public void PlayerLoad()
        {
            playerFrame1 = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-2d-game/assets/graphics/robot character1.png");
            playerFrame2 = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-2d-game/assets/graphics/robot character2.png");
            playerHurt = Graphics.LoadTexture("C:/Users/lifew/source/repos/marshall-jordan-a3-2d-game/assets/graphics/robot character hurt1.png");
            float mouseX = Input.GetMouseX() - 28;
            float mouseY = Input.GetMouseY() - 44;

            if (Input.IsMouseButtonDown(0))
            {
                Graphics.Draw(playerFrame2, mouseX, mouseY);
            }
            else if (mouseX >= 243 && mouseX <= 308 && mouseY >= 610 && mouseY <= 670)
            {
                Graphics.Draw(playerHurt, mouseX, mouseY);
            }
            else
            {
                Graphics.Draw(playerFrame1, mouseX, mouseY);
            }
        }
    }
}
