using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserLibrary
{
    public abstract class Analyzer
    {
        #region Protected

        protected string _pathToFile;

        #endregion

        public Analyzer(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public abstract void GetCountStringOverlaps(out int countOverlaps);
    }
}
