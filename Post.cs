using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace PA1_abrush60
{
    public class Post : IComparable<Post>
    {
        public int Id{get; set;}

        public string Text{get; set;}

        public DateTime Timestamp{get; set;}

        public int CompareTo(Post temp)
        {
            return this.Timestamp.CompareTo(temp.Timestamp);
        }

        public static int CompareId(Post x,Post y)
        {
            return x.Id.CompareTo(y.Id);
        }

        public override string ToString()
        {
            return "\nID:" + Id + "\tOrignial Post: " + Text + "\nTime Posted: " + Timestamp; 
        }

        public static void AddPost(List<Post> posts)
        {
            //Console.Clear;
            Console.WriteLine("Please enter your post.");
            string userPost = Console.ReadLine();
            Console.WriteLine(posts.Count);

            posts.Add(new Post() {Id = posts.Count, Text = userPost, Timestamp = DateTime.Now});

        }

        public static void RemovePost(List<Post> posts)
        {
            int found = Post.BinarySearch(posts);
            posts.Remove(posts[found]);
        }

        public static int BinarySearch(List<Post> posts)
        {
            Console.WriteLine("Delete post\nEnter ID number of the post you wish to delete.");
            int removeInput = int.Parse(Console.ReadLine());
            int first = 0;
            int last = posts.Count;

            while(last>=first)
            {
                int middle = (first + last)/2;
                int holder =  posts[middle].Id;
                if (holder == removeInput)
                {
                    return middle;
                }
                if(holder > removeInput)
                {
                    last = middle - 1;
                }
                else{
                    first = middle +1;
                }
            }
            Console.WriteLine("Requested ID does not exist.\nReturning...");
            return -1;
        }

        public static void SaveFile(List<Post> posts)
        {
            int outId = 0;
            string outText = "";
            DateTime outTimestamp = DateTime.Now;
            StreamWriter file = new StreamWriter("posts.txt");

            for(int x = 0; x < posts.Count; x++)
            {
                outId = posts[x].Id;
                outText = posts[x].Text;
                outTimestamp = posts[x].Timestamp;

                file.WriteLine(outId +"#" + outText +"#"+outTimestamp);

            }
            file.Close();
        }

    }
}