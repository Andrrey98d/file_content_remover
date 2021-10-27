using System;
using System.Collections.Generic;
using System.IO;

namespace file_content_remover
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Enter filename to read (without extension)");
            string read_path = Console.ReadLine();
            Console.WriteLine("Enter filename to write (without extension)");
            string write_path = Console.ReadLine();
            Console.WriteLine("Done...\n");
            attributes_ ar = new();
            ar.attr(ref read_path, ref write_path);
            StreamReader sr;
            sr = new(read_path);        
            StreamWriter sw = new(write_path); // is dynamic
            List<char> read_array = new List<char>(); // file "array" from first file
            FileInfo fl = new(read_path);
            ar.props_(ref fl, ref read_path); // in case of read_path; similar method with write_path

            using (sr)
            {
                string temp_string = sr.ReadToEnd();
                char[] temp_array = temp_string.ToCharArray(); // conv
             
                    for (int k = 0; k < temp_array.Length; k++)
                    {
                        read_array.Add(temp_array[k]);
                    }
                    if (read_array.Count > 10)
                    {
                        Console.WriteLine("done!");
                    }
                    else
                    {
                        Console.WriteLine("Length: 0");
                    }
                
                sr.Close();
            }

            using (sw)
            {
                for(int k = 0; k <read_array.Count; k++)
                {
                    sw.Write(read_array[k]);
                }    
                FileInfo f_wr = new(write_path);
                var msg = f_wr?.Length <= read_array?.Count + 1 ? "OK" : "Error, file length is less than array";// добавили +1 индекс, для запаса
                if (msg.Length > 3)
                {
                    Console.WriteLine(msg);
                    return;
                }
                else
                    Console.WriteLine(msg);
                FileInfo flinf = new(read_path);
                flinf.Delete();
                Console.WriteLine($"{read_path} deleted!");
                sw.Close();
            }
        }

        protected static void Notify_user(ref int index)
        {
            Console.WriteLine($"Index out of bounds on {0} position", index);
        }
    }
}
