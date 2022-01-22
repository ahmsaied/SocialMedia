using System;

namespace Domain
{
    public class User
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public int UserAge { get; set; }
    }
}
