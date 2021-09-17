using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class MediaQuantityUpdate
    {
        public int MediaIdToUpdate { get; set; }

        public int NewQuantity { get; set; }

    }
}
