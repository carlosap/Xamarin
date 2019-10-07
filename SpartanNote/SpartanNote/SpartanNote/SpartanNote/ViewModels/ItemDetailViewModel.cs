using System;
using System.Collections.Generic;
using SpartanNote.Models;

namespace SpartanNote.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        //public Item Item { get; set; }
        public Note Note { get; set; }
        public IList<String> CourseList { get; set; }

        //INotifier properties
        public String NoteHeading
        {
            get { return Note.Heading; }
            set
            {
                Note.Heading = value;
                OnPropertyChanged();
            }
        }


        //public ItemDetailViewModel(Item item = null)
        public ItemDetailViewModel(Note note = null)
        {
            //Title = item?.Text;
            Title = "Edit Note";
            InitCourseList();
            //Item = item;
            //Note = new Note
            //{
            //    Heading = "Test Node for Heading",
            //    Text = "Text for note in ViewModel",
            //    Course = CourseList[0]
            //};
            Note = note ?? new Note();

        }

        async void InitCourseList()
        {
            CourseList = await NoteDataStore.GetCoursesAsync();
        }
    }
}
