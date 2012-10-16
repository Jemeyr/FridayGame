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
    class Hobby
    {
        public static Texture2D[] textures;
        
        public int id;
        public float skill;
        public float interest;

        public Hobby()
        {

            id = World.random.Next(8);
            skill = (float)World.random.NextDouble();
            interest = (float)World.random.NextDouble();
        }

    }
}
