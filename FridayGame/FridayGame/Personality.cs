using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FridayGame
{
    class Personality
    {

        

        public float gender;                //poles are ideal, people too far from poles range out of social norms
        public float genderPreference;      //what gender people are attracted to

        public float attractive;            //1 = ideal, 0 = total fugs
        public float amiability;            //1 = ideal, 0 = superficially unlikable

        public float friendliness;          //1 = always nice, 0 = always mean to strangers
        public float leadership;            //1 = ideal leader, 0 = perfect loyalty
        
        public float confidence;            //willingness to do things
        public float social;                //how likely you are to want to start something


        public Personality()
        {
            this.gender = World.random.Next(2) == 1 ? 1 : 0;
            this.genderPreference = World.random.Next(2) == 1 ? 1 : 0;

            this.attractive = World.random.Next(2);
            this.amiability = World.random.Next(2);

            this.friendliness = World.random.Next(2);
            this.leadership = World.random.Next(2);

            this.confidence = World.random.Next(2);
            this.social = World.random.Next(2);
        }


        
    }
}
