using System.Collections.Generic;
using HtmlAgilityPack;
using System;
public class Parser
{
    private string url = "https://www.udemy.com/course/learn-flutter-dart-to-build-ios-android-apps/";
    private HtmlWeb htmlWeb;
    public Parser()
    {
        htmlWeb = new HtmlWeb();        
    }

    public void ParseLectures(ref List<Lecture> lectures)
    {
        HtmlDocument htmlDocument = htmlWeb.Load(url);
        HtmlNodeCollection freeLecturesDivs = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'lecture-container--preview')]");
        foreach(var freeLectureDiv in freeLecturesDivs)
        {
            var lectureTitleDiv = freeLectureDiv.SelectSingleNode(".//div[@class='title']");
            var lectureDetailsDiv = freeLectureDiv.SelectSingleNode(".//div[@class='details']");
            var lectureTitle = lectureTitleDiv.SelectSingleNode("a").InnerText;            
            var lectureDuration = lectureDetailsDiv.SelectSingleNode("span[@class='content-summary']").InnerText;

            TimeSpan tempDuration = new System.TimeSpan(0, Int32.Parse(lectureDuration.Substring(0, lectureDuration.IndexOf(":"))), 
                                                    Int32.Parse(lectureDuration.Substring(lectureDuration.IndexOf(":") + 1)));
            Lecture lecture = new Lecture
            {
                Title = lectureTitle,                
                Duration = tempDuration           
            };
            lectures.Add(lecture);
        }
    }
}