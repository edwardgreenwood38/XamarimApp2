using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XamarimApp2
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();
            
            EraseNoteCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveNoteCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);

                TheNote = string.Empty;
            });
        }

        public ObservableCollection<string> AllNotes { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {
            get => theNote;

            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));


                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveNoteCommand { get; }

        public Command EraseNoteCommand { get; }
    }
}
