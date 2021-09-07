using System;
using System.Collections.Generic;

namespace PA1_abrush60
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            
            //Console.WriteLine(now);

            List<Post> bigalPost = PostFile.GetPost();

            //Console.ReadKey();

            // foreach (Post x in bigalPost)
            //         {
            //             Console.WriteLine("ID:"+ x.Id +"\t Post:"+ x.Text + "\n Date: " + x.Timestamp);
            //         }
            // Console.ReadKey();

            int menuChoice = DisplayMenu();

            while (menuChoice !=4)
            {
                if(menuChoice == 1)
                {
                    bigalPost.Sort();
                    PostUtils.PrintAllPost(bigalPost);
                    Console.ReadKey();
                }
                else if(menuChoice == 2)
                {
                    Console.WriteLine("Add a post");
                    Post.AddPost(bigalPost);
                    bigalPost.Sort(Post.CompareId);
                    Post.SaveFile(bigalPost);
                }
                else if (menuChoice == 3)
                {
                    Post.RemovePost(bigalPost);
                    bigalPost.Sort(Post.CompareId);
                    Post.SaveFile(bigalPost);
                    Console.WriteLine("Post Successfully Deleted.");
                }
                else 
                {
                    Console.WriteLine("Invalid Input. Try again.");
                    Console.ReadKey();
                }
                menuChoice = DisplayMenu();
            }            
        }

        public static int DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to Big Al's Social PostBase!\nPlease select a menu option.");
            Console.WriteLine("");
            Console.WriteLine("1.Show all posts (Timestamp Order)\n\t2.Add a Post\n\t\t3.Delete Post\n\t\t\t4.Exit");
            int menuChoice = int.Parse(Console.ReadLine());
            return menuChoice;

        }
    }
}
