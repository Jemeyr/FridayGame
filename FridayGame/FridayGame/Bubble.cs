using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FridayGame
{
    class Bubble
    {
        public static Texture2D texture;

        public int hobbyId;

        public Bubble(int hobbyId)
        {
            this.hobbyId = hobbyId;
        }

        public void draw(SpriteBatch spriteBatch, Vector2 pos)
        {
            spriteBatch.Draw(texture, pos, Color.White);
            spriteBatch.Draw(Hobby.textures[hobbyId], pos, Color.White);
        }

        


        public static void setTexture(Texture2D text)
        {
            Bubble.texture = text;
        }


    }
}
