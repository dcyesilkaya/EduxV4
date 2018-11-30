using System;
using System.Collections.Generic;
using System.Text;

namespace EduxV4.Data
{
    public class ContactHomework
    {
        public string ContactId { get; set; }
        public Contact Contact { get; set; }

        public string HomeworkId { get; set; }
        public Homework Homework { get; set; }
    }
}
