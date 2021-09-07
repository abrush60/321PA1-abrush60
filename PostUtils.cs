using System.IO;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PA1_abrush60
{
    public class PostUtils
    {
        public static void PrintAllPost(List<Post> posts)
        {
            foreach (Post post in posts)
                    {
                        Console.WriteLine(post.ToString());
                    }
        }

    }
}