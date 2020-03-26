using System.Collections.Generic;
using System;
using System.Linq;

namespace vparser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lecture> lectures = new List<Lecture>();

            Parser parser = new Parser();
            parser.ParseLectures(ref lectures);

            RemoveHtmlEntities(ref lectures);
            PrintLectures(ref lectures);
        }

        public static void PrintLectures(ref List<Lecture> lectures)
        {
            foreach(var lecture in lectures.OrderBy(l => l.Duration))
            {                
                Console.WriteLine("Lecture: " + lecture.Title);
                Console.WriteLine("Time duration:" + lecture.Duration);
                Console.WriteLine('\n');
            }
        }

        public static void RemoveHtmlEntities(ref List<Lecture> lectures)
        {
            lectures.ForEach(lecture => { lecture.Title = lecture.Title.Replace("&amp;", string.Empty); 
                                          lecture.Title = lecture.Title.Trim(); });            
        }

    }
}
