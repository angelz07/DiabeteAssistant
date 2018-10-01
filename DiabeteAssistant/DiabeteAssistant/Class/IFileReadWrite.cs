using System;
using System.Collections.Generic;
using System.Text;

namespace DiabeteAssistant.Class
{
    public interface IFileReadWrite
    {
        void WriteData(string fileName, string data);
        string ReadData(string filename);
        Boolean IsFileExiste(string filename);
    }
}
