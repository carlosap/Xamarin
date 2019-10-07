using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartanNote.Models;

namespace SpartanNote.Services
{
    public class MockNoteDataStore: INoteDataStore
    {
        private static readonly List<String> mockCourses;
        private static readonly List<Note> mockNotes;
        private static int nextNoteId;

        static MockNoteDataStore()
        {
            mockCourses = new List<string>
            {
                "Intro1 to Math1",
                "Intro2 to Math2",
                "Intro3 to Math3"
            };

            mockNotes = new List<Note>
            {
                new Note{Id = "0", Heading = "UI Dtest0", Text = "Forms to UI0", Course = mockCourses[0]},
                new Note{Id = "1", Heading = "UI Dtest1", Text = "Forms to UI1", Course = mockCourses[1]},
                new Note{Id = "2", Heading = "UI Dtest2", Text = "Forms to UI2", Course = mockCourses[0]},
                new Note{Id = "3", Heading = "UI Dtest3", Text = "Forms to UI3", Course = mockCourses[2]},
                new Note{Id = "4", Heading = "UI Dtest4", Text = "Forms to UI4", Course = mockCourses[1]},
                new Note{Id = "5", Heading = "UI Dtest5", Text = "Forms to UI5", Course = mockCourses[2]},

            };

            nextNoteId = mockNotes.Count;
        }

        public async Task<string> AddNoteAsync(Note note)
        {
            lock (this)
            {
                note.Id = nextNoteId.ToString();
                mockNotes.Add(note);
                nextNoteId++;
            }
            return await Task.FromResult(note.Id);
        }

        public async Task<bool> UpdateNoteAsync(Note note)
        {
            var noteIndex = mockNotes.FindIndex((Note arg) => arg.Id == note.Id);
            var noteFound = noteIndex != -1;
            if (noteFound)
            {
                mockNotes[noteIndex].Heading = note.Heading;
                mockNotes[noteIndex].Text = note.Text;
                mockNotes[noteIndex].Course = note.Course;
            }
            return await Task.FromResult(noteFound);
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            var note = mockNotes.FirstOrDefault(courseNote => courseNote.Id == id);
            // Make a copy of the note to simulate reading from an external datastore
            var returnNote = CopyNote(note);
            return await Task.FromResult(returnNote);
        }

        public async Task<IList<Note>> GetNotesAsync()
        {
            // Make a copy of the notes to simulate reading from an external datastore
            var returnNotes = new List<Note>();
            foreach (var note in mockNotes)
                returnNotes.Add(CopyNote(note));
            return await Task.FromResult(returnNotes);
        }

        public async Task<IList<string>> GetCoursesAsync()
        {
            return await Task.FromResult(mockCourses);
        }

        private static Note CopyNote(Note note)
        {
            return new Note { Id = note.Id, Heading = note.Heading, Text = note.Text, Course = note.Course };
        }
    }
}
