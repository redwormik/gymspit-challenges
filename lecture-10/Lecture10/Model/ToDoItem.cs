using System;


namespace Lecture10.Model
{
    public class ToDoItem
    {
        public string Label { get; set; }

        public bool Done { get; set; }


        public ToDoItem(string label, bool done = false)
        {
            Label = label;
            Done = done;
        }
    }
}
