using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.SqlServer.Server;

namespace FileParserLibrary
{
    public class TextAnalyzer : Analyzer
    {
        #region Private

        private StreamReader _fileReader;
        private string _necessaryString;

        #endregion
        
        public TextAnalyzer(string pathToFile, string necessaryString)
            : base(pathToFile)
        {
            _necessaryString = necessaryString;
            _fileReader = new StreamReader(_destinetionFile);
        }

        public override void GetCountStringOverlaps(out int countOverlaps)
        {
            countOverlaps = 0;
            string line = string.Empty;

            while ((line = _fileReader.ReadLine()) != null)
            {
                if (line.Contains(_necessaryString))
                {
                    string[] arr = new string[1];
                    arr[0] = _necessaryString;
                    string[] lines = line.Split(new string[] { _necessaryString}, 
                            StringSplitOptions.RemoveEmptyEntries);
                    countOverlaps += lines.Length - 1;
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
