using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    public class Course
    {
        public Course(string title, string description, double progress)
        {
            Title = title;
            Description = description;
            Progress = progress;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Progress { get; set; }
        public bool Done => Progress >= 100;
    }
}
