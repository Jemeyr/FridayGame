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
    class World
    {
        public static int XSIZE = 30;
        public static int YSIZE = 18;
        public static int IMGSIZE = 128;

        public static Random random;

        public Tile[][] tiles;
        public bool isReady = false;

        public World()
        {

            random = new Random();

            this.tiles = new Tile[XSIZE][];
            for (int i = 0; i < XSIZE; i++)
            {
                tiles[i] = new Tile[YSIZE];
                for (int j = 0; j < YSIZE; j++)
                {
                    tiles[i][j] = new Tile(new Vector2(IMGSIZE * i,IMGSIZE * j));
                }
            }

            createHalls();
            connectHalls();
            markIntersections();
        }

        public void draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < XSIZE; i++)
            {
                for (int j = 0; j < YSIZE; j++)
                {
                    tiles[i][j].draw(spriteBatch);
                }
            }
        }

        public List<Tile> getTiles(Vector2 pos)
        {
            List<Tile> ret = new List<Tile>();
            try
            {
                ret.Add(this.tiles[(int)pos.X / IMGSIZE][(int)pos.Y / IMGSIZE]);
                ret.Add(this.tiles[(int)(pos.X + 32) / IMGSIZE][(int)pos.Y / IMGSIZE]);
                ret.Add(this.tiles[(int)pos.X / IMGSIZE][(int)(pos.Y + 32) / IMGSIZE]);
                ret.Add(this.tiles[(int)(pos.X + 32) / IMGSIZE][(int)(pos.Y + 32) / IMGSIZE]);
            }
            catch{ };
            return ret.Distinct<Tile>().ToList<Tile>();//remove duplicates. Fuck yeah.
        }

        public Vector2 getValidDir(Vector2 pos)
        {
            List<Vector2> ret = new List<Vector2>();

            int y = (int)pos.Y / IMGSIZE;
            int x = (int)pos.X / IMGSIZE;

            try
            {
                if (tiles[x + 1][y].passable)
                {
                    ret.Add(new Vector2(1, 0));
                }
                if (tiles[x - 1][y].passable)
                {
                    ret.Add(new Vector2(-1, 0));
                }
                if (tiles[x][y - 1].passable)
                {
                    ret.Add(new Vector2(0, -1));
                }
                if (tiles[x][y + 1].passable)
                {
                    ret.Add(new Vector2(0, 1));
                }
            }
            catch  { return Vector2.Zero; }

            if (ret.Count == 0)
            {
                return Vector2.Zero;
            }
            
            

            Vector2 fin = ret.ElementAt(random.Next(ret.Count));

            return fin;
        }

        public void createHalls()
        {

            //generate base halls
            int halls = 12;


            for (int k = 0; k < halls; k++)
            {
                Vector2 start = new Vector2(1 + random.Next((World.XSIZE - 1) / 3) * 3, 1 + random.Next((World.YSIZE - 1) / 3) * 3);
                if (tiles[(int)start.X][(int)start.Y].passable)
                {
                    k--;
                    continue;
                }

                int rand = random.Next(4);
                if (rand == 0)
                {
                    for (int i = (int)start.X; i < World.XSIZE - 1; i++)
                    {
                        tiles[i][(int)start.Y].passable = true;
                    }
                }
                else if (rand == 1)
                {
                    for (int i = (int)start.Y; i < World.YSIZE - 1; i++)
                    {
                        tiles[(int)start.X][i].passable = true;
                    }
                }
                else if (rand == 2)
                {
                    for (int i = (int)start.X; i > 0; i--)
                    {
                        tiles[i][(int)start.Y].passable = true;
                    }
                }
                else
                {
                    for (int i = (int)start.Y; i > 0; i--)
                    {
                        tiles[(int)start.X][i].passable = true;
                    }
                }
            }
        }

        public void connectHalls()
        {

            for (int i = 1; i < World.XSIZE - 1; i++)
            {
                tiles[i][1].passable = true;
                tiles[i][World.YSIZE - 2].passable = true;
            }

            for (int i = 1; i < World.YSIZE - 1; i++)
            {
                tiles[1][i].passable = true;
                tiles[World.XSIZE - 2][i].passable = true;
            }

        }

        public void markIntersections()
        {
            for (int i = 0; i < XSIZE; i++)
            {
                for (int j = 0; j < YSIZE; j++)
                {
                    if (!tiles[i][j].passable)
                    {
                        continue;
                    }

                    int xpass = 0;
                    int ypass = 0;

                    if(i > 0 && tiles[i - 1][j].passable)
                    {
                        xpass++;
                    }
                    if(i < XSIZE - 1 && tiles[i + 1][j].passable)
                    {
                        xpass++;
                    }
                    if(j > 0 && tiles[i][j-1].passable) 
                    {
                        ypass++;
                    }

                    if (j < YSIZE - 1 && tiles[i][j+1].passable)
                    {
                        ypass++;
                    }

                    if((xpass > 0 && ypass > 0) || (xpass == 1 && ypass==0) || (xpass == 0 && ypass == 1))
                    {
                        tiles[i][j].intersection = true;
                    }
                }
            }

        }


    }
}
