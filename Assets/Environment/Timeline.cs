using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureTEST
{
    internal class Timeline
    {
        public Timeline(IList<Snapshot> snaps)
        {
            snapshots = new List<Snapshot>(snaps);
        }
        public IList<Snapshot> snapshots;

    }
}
