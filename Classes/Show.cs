using System.Collections.Generic;

namespace Gabriel.Shows
{
    public class Show : Entity
    {
        public int episodes { get; private set; }

        public Show( int id, Genre genre, string title, string description, int launchYear, int episodes) : base( id, genre, title, description, launchYear)
        {
            this.episodes = episodes;
        }

        public override string ToString()
        {
            return  base.ToString() + "\n" + "Episodes: " + this.episodes;
        }
    }
}