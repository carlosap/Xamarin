using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SpartanNote.Models;
using SpartanNote.Views;

namespace SpartanNote.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        //public ObservableCollection<Item> Items { get; set; }
        //ObservableCollection events notify the Ul of changes such as add/remove an item
        public ObservableCollection<Note> Notes { get; set; }

        //exposoe execute load command func as a property.
        //this is very important from a data binding stand-point of view.
        //in order to access the member of the class, members needs to be a public property
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            //Items = new ObservableCollection<Item>();
            Notes = new ObservableCollection<Note>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            MessagingCenter.Subscribe<NewItemPage, Note>(this, "SaveNote", async (obj, note) =>
            {
                var newNote = note as Note;
                Notes.Add(newNote);
                await NoteDataStore.AddNoteAsync(newNote);
                //await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            //pattern use to protect async functions
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                //Items.Clear();
                Notes.Clear();
                //var items = await DataStore.GetItemsAsync(true);
                var notes = await NoteDataStore.GetNotesAsync();
                //foreach (var item in items)
                foreach (var item in notes)
                {
                    //Items.Add(item);
                    Notes.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}