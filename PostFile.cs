using System.IO;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PA1_abrush60
{
    public class PostFile
    {

        
        public static List<Post> GetPost()
        {
            List<Post> bigalPost =  new List<Post>();
            StreamReader inFile = null;

            try
            {
                inFile =  new StreamReader("posts.txt");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Something went wrong.. returning blank list {0}", e);
                return bigalPost;
            }

            string line =  inFile.ReadLine(); //prime
            while(line!=null)
            {
                string[] temp = line.Split('#');
                int Id = int.Parse(temp[0]);
                DateTime date =  DateTime.Parse(temp[2]);


                bigalPost.Add(new Post(){Id=Id, Text = temp[1], Timestamp = date});
                line = inFile.ReadLine();
            }

            inFile.Close();

            return bigalPost;
        }
    }
}