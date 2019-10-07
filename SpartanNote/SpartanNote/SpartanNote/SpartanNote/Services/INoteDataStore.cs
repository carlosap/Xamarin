using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SpartanNote.Models;

namespace SpartanNote.Services
{
    public interface INoteDataStore
    {
        Task<String> AddNoteAsync(Note note);
        Task<bool> UpdateNoteAsync(Note note);
        Task<Note> GetNoteAsync(String id);
        Task<IList<Note>> GetNotesAsync();
        Task<IList<String>> GetCoursesAsync();

    }
}
