using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserLibrary
{
    public abstract class Analyzer : IDisposable
    {
        #region Protected

        protected string _pathToFile;
        protected FileStream _destinetionFile;
        protected bool _isDisposed;

        #endregion

        public Analyzer(string pathToFile)
        {
            _pathToFile = pathToFile;
            _destinetionFile = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            _isDisposed = false;
        }

        public abstract void GetCountStringOverlaps(out int countOverlaps);

        public void Dispose()
        {
            Clear();
            GC.SuppressFinalize(this);
        }

        protected virtual void Clear()
        {
            if (!_isDisposed)
            {
                _destinetionFile.Dispose();
            }

            _isDisposed = true;
        }

        ~ Analyzer()
        {
            Clear();
        }
    }
}
