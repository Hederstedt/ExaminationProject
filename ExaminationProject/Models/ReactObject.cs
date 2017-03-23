using ExaminationProject.Models.ProjektModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.Models
{
    public class ReactObject
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public IFormFile File { get; set; }
    }
    public static class TempObject
    {
        private static List<ReactObject> tempData;
        private static List<ProjectImageModel> imageList;
        private static List<ProjectHeadersModel> headerList;
        private static List<ProjectTextModel> textList;

        static TempObject()
        {
            tempData = new List<ReactObject>();
            imageList = new List<ProjectImageModel>();
            headerList = new List<ProjectHeadersModel>();
            textList = new List<ProjectTextModel>();
        }
        public static void AddToTempText(ProjectTextModel t)
        {
            textList.Add(t);
        }
        public static List<ProjectTextModel> GetTempText()
        {
            return textList;
        }
        public static void AddToTempHeader(ProjectHeadersModel h)
        {
            headerList.Add(h);
        }
        public static List<ProjectHeadersModel> GetTempHeader()
        {
            return headerList;
        }
        public static void AddToTempImage(ProjectImageModel i)
        {
            imageList.Add(i);
        }
        public static List<ProjectImageModel> GetTempImage()
        {
            return imageList;
        }
        public static void AddToTemp(ReactObject r)
        {
            tempData.Add(r);
        }
        public static List<ReactObject> GetTempData()
        {
            return tempData;
        }
    }
    
}
