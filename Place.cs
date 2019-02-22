using System.Collections.Generic;

namespace Lab1.Model
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string Session { get; set; }
        public int PlaceNumber { get; set; }
        public bool Employment { get; set; } 
        public virtual ICollection<Session> Sessions { get; set; }
        public Place()
        {
            Sessions = new List<Session>();
        }
    }
}
