using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_content_remover
{
    class attributes_
    {
        internal string path_link { get; set; }

        internal void attr(ref string read_path, ref string write_path)
        {    
            read_path = read_path.Insert(0, "D:\\");
            read_path = read_path.Insert(read_path.Length, ".txt"); // user determines the filename, file ext is *.txt for default, at first time
            write_path = write_path.Insert(0, "D:\\");
            write_path = write_path.Insert(write_path.Length, ".txt"); 
        }
        internal void props_ (ref FileInfo fl_old, ref string path) //
        {
            this.path_link = path;
            FileInfo fprop = new(path);
            fl_old = fprop;
            return;
        }


    }
}
