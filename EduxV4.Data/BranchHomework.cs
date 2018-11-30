using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class BranchHomework
    {
        public string BranchId { get; set; }
        public Branch Branch { get; set; }

        public string HomeworkId { get; set; }
        public Homework Homework { get; set; }
    }
}
