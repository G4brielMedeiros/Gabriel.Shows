namespace Gabriel.Shows
{
    public abstract class Entity
    {
        public int id { get; protected set; }

        public Genre genre { get; protected set; }

        public string title { get; protected set; }

        public string description { get; protected set; }

        public int launchYear { get; protected set; }

        public bool deleted {get; protected set;}

        protected Entity(int id, Genre genre, string title, string description, int launchYear)
        {
            this.id = id;
            this.genre = genre;
            this.title = title;
            this.description = description;
            this.launchYear = launchYear;
        }

        public void Delete()
        {
            deleted = true;
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