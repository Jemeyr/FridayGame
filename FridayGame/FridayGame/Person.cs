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
    class Person
    {
        public static int currId = 0;
        public static Texture2D texture;


        public Vector2 dir;
        public Tile currentTile;

        public Vector2 position;
        public int id;

        public Color color;//clique color

        public Personality personality;                 //info about particular things

        public List<Relationship> relationships;
        public List<Hobby> hobbies;

        public Bubble bubble;

        
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color);
            if (bubble != null)
            {
                bubble.draw(spriteBatch, (position - new Vector2(32f,16f)));
            }
        }

        public void update(World w)
        {
            

            this.position += dir;

            List<Tile> thing = w.getTiles(this.position);


            if (!thing.Contains(this.currentTile))
            {
                if (thing.Count > 0)
                {
                    this.currentTile = thing.First<Tile>();
                }
                else
                {
                    this.dir = Vector2.Zero;
                }
                
                if (this.currentTile.intersection)
                {
                    this.dir = w.getValidDir(this.position);
                }
                

            }

        }

        public Person(Vector2 position, World w)
        {
            this.id = currId++;
            this.position = position;

            this.personality = new Personality();

            this.relationships = new List<Relationship>();
            this.hobbies = new List<Hobby>();

            generateHobbies(hobbies);

            this.color = Color.Black;

            this.bubble = new Bubble(hobbies.First<Hobby>().id);



            this.dir = w.getValidDir(this.position);

            this.currentTile = w.getTiles(this.position).First<Tile>();

        }

        public void generateHobbies(List<Hobby> hobbies)
        {
            hobbies.Add(new Hobby());
        }

        public static void setTexture(Texture2D tex)
        {
            Person.texture = tex;
        }

    }
}
