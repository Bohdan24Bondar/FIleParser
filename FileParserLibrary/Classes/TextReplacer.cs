using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserLibrary
{
    public class TextReplacer : Replacer
    {
        #region Private

        private StreamReader _fileReader;
        private string _searchedString;

        #endregion

        public TextReplacer(string pathToFile, string searchedString)
            : base(pathToFile)
        {
            _searchedString = searchedString;
            _fileReader = new StreamReader(_destinetionFile);
        }

        public override void ReplaceString(string replacedString)
        {
            string line = string.Empty;

            while ((line = _fileReader.ReadLine()) != null)
            {
                if (line.Contains(_searchedString))
                {
                    line.Replace(_searchedString, replacedString);
                    ReplacedCount++;
                }
            }
        }

        protected override void Clear()
        {
            if (!_isDisposed)
            {
                _fileReader.Dispose();
                _destinetionFile.Dispose();
            }

            _isDisposed = true;
        }
    }
}
