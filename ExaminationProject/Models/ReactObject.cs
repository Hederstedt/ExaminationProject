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

        static TempObject()
        {
            tempData = new List<ReactObject>();
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
