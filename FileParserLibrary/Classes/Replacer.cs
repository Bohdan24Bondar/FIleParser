using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserLibrary
{
    public abstract class Replacer
    {
        #region Private

        protected int _maxBufferSize;
        protected string _pathToFile;
        protected Queue<string> _buffer;
        protected string _pathToTempFile;

        #endregion

        public Replacer(string pathToFile, int maxBufferSize)
        {
            _pathToFile = pathToFile;
            _maxBufferSize = maxBufferSize;
            _buffer = new Queue<string>();
            _pathToTempFile = string.Format("{0}.txt", Path.GetRandomFileName());
        }

        public int ReplacementsCount { get; protected set; }

        public abstract void ReplaceString(string searchedString, string replacedString);

    }
}
