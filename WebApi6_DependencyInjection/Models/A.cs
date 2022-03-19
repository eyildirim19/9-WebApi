using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi6_DependencyInjection.Models
{
    public class FileOperation
    {
        public IFile file { get; set; }

        public FileOperation(IFile _file)
        {
            file = _file;
        }


        public void ReadFile()
        {
        }
    }


    public class AnaProgram
    {
        void Main()
        {
            TextFile txt = new TextFile("..path");
            FileOperation file = new FileOperation(txt);

            JsonFile jj = new JsonFile();
            FileOperation operason2 = new FileOperation(jj);

            XmlFile xl = new XmlFile();
            FileOperation ops2 = new FileOperation(xl);

        }
    }
}
