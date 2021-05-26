using System.Collections.Generic;
using Project.Shows.Interfaces;

namespace Project.Shows
{
    public class ShowsRepository : IRepository<Show>
    {

        private List<Show> showList = new List<Show>();
        public void Insert(Show show)
        {
            showList.Add(show);
        }

        public void DeleteById(int id)
        {
            showList[id].Delete();
        }

        public List<Show> List()
        {
            return showList;
        }

        public int NextId()
        {
            return showList.Count;
        }

        public Show ReadById(int id)
        {
            return showList[id];
        }

        public void UpdateById(int id, Show show)
        {
            showList[id] = show;
        }
    }
}