using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FridayGame
{
    class Relationship
    {
        int id; //person with whom you have the relationship

        float trust;
        float like;
        bool crush;

        float ptrust;
        float plike;
        bool pcrush;

        public Relationship()
        {
            id = 9;

            this.trust = (float)World.random.NextDouble();
            this.like = (float)World.random.NextDouble();
            this.ptrust = (float)World.random.NextDouble();
            this.plike = (float)World.random.NextDouble();

            this.crush = trust + like > ptrust + plike;
            this.pcrush = id == 7;
        }


    }
}
