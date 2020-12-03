using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSD
{
    class Location
    {
        private string type;
        private string name;

        public Location(string type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public Location()
        {

        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
