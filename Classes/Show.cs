using System.Collections.Generic;

namespace Project.Shows
{
    public class Show : Entity
    {
        public Genre genre { get; private set; }

        public string title { get; private set; }

        public string description { get; private set; }

        public int launchYear { get; private set; }

        public bool deleted {get; private set;}

        public Show( int id, Genre genre, string title, string description, int launchYear)
        {
            this.id = id;
            this.genre = genre;
            this.title = title;
            this.description = description;
            this.launchYear = launchYear;
            this.deleted = false;
        }

        public void Delete()
        {
            this.deleted = true;
        }

        public override string ToString()
        {
            return  "Genre: "       + this.genre        + "\n" +
                    "Title: "       + this.title        + "\n" +
                    "Description: " + this.description  + "\n" +
                    "Launch year: " + this.launchYear   + "\n" +
                    "Deleted: "     + this.deleted;
        }
    }
}