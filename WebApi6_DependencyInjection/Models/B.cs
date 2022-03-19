using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi6_DependencyInjection.Models
{
    public interface IFile
    {

    }

    public class TextFile : IFile
    {
        public TextFile(string str)
        {
        }
    }

    public class JsonFile : IFile
    {

    }

    public class XmlFile : IFile
    {

    }
}
