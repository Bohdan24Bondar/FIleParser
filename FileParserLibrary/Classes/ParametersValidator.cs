using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserLibrary
{
    public class ParametersValidator
    {
        #region Private

        private string _pathToFolder;

        #endregion

        public ParametersValidator(string pathToFile)
        {
            _pathToFolder = pathToFile;
        }
        
        public bool IsExistFile 
        {
            get
            {
                return File.Exists(_pathToFolder);
            }
        }

        public bool IsStringEmpty(string necessaryString)
        {
            return necessaryString == string.Empty;
        }
    }
}
