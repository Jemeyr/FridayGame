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
    class Tile
    {
        static Texture2D texture;
        public bool passable;
        public Vector2 position;

        public bool intersection;

        


        public Tile(Vector2 position)
        {
            this.position = position;
            this.passable = false;
            this.intersection = false;
        }

        public static void setTexture(Texture2D tex)
        {
            Tile.texture = tex;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tile.texture, position, passable ? intersection? Color.LightSeaGreen : Color.White : Color.DarkBlue);
        }

    }
}
