using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserLibrary
{
    public abstract class Replacer : IDisposable
    {
        #region Private

        protected string _pathToFile;
        protected FileStream _destinetionFile;
        protected bool _isDisposed;

        #endregion

        public Replacer(string pathToFile)
        {
            _pathToFile = pathToFile;
            _destinetionFile = new FileStream(pathToFile, FileMode.Open, FileAccess.ReadWrite);
            _isDisposed = false;
            ReplacedCount = 0;
        }

        public int ReplacedCount { get; protected set; }

        public abstract void ReplaceString(string replacedString);

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

        ~Replacer()
        {
            Clear();
        }
    }
}
