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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera2D cam;

        World world;
        List<Person> people;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.setTexture(Content.Load<Texture2D>("tile"));
            Person.setTexture(Content.Load<Texture2D>("person"));
            Bubble.setTexture(Content.Load<Texture2D>("bubble"));

            Texture2D[] hobbies = new Texture2D[8];
            for (int i = 0; i < 8; i++)
            {
                hobbies[i] = Content.Load<Texture2D>("hobby" + i);
            }

            Hobby.textures = hobbies;

            this.cam = new Camera2D(GraphicsDevice.Viewport);
            cam.Zoom = .25f;

            this.world = new World();
            

            people = new List<Person>();

            populate(people);

            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            Vector2 move = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                move -= Vector2.UnitY;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                move += Vector2.UnitY;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                move -= Vector2.UnitX;
            
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                move += Vector2.UnitX;
            }

            cam.MoveCamera(move * 10f);

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            // TODO: Add your update logic here

            foreach (Person p in people)
            {
                p.update(world);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, cam.GetCameraTransformation());

            world.draw(spriteBatch);
            // TODO: Add your drawing code here

            foreach (Person p in people)
            {
                p.draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }


        void populate(List<Person> people)
        {

            int x,y;
            Vector2 attempt;
            for (int i = 0; i < 16; i++)
            {
                //get random point.
                do
                {
                    y = World.random.Next(World.YSIZE);
                    x = World.random.Next(World.XSIZE);


                    attempt = new Vector2(World.IMGSIZE * x + 32 * World.random.Next(4), World.IMGSIZE * y + 32 * World.random.Next(4));

                } while (!world.tiles[x][y].intersection);//was passable

                people.Add(new Person(attempt, world));

            }
        }
    }
}
