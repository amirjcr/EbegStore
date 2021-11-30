using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_FrameWork.Domain
{
    public class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpDateDate { get; set; }

        public long UserId { get; set; }
    }
}
