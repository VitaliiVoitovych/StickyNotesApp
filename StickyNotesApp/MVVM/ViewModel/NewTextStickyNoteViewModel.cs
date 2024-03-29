﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StickyNotesApp.MVVM.Models;
using StickyNotesApp.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace StickyNotesApp.MVVM.ViewModel
{
    public partial class NewTextStickyNoteViewModel : ObservableObject
    {
        private readonly BindingList<StickyNote> stickyNotes;

        [ObservableProperty]
        private Brush color = (SolidColorBrush)new BrushConverter().ConvertFrom("#3AAF97")!;

        [ObservableProperty]
        private StickyNote stickyNote = new();

        [RelayCommand]
        private void ColorChange(RadioButton radioButton)
        {
            Color = radioButton.Background;
        }

        [RelayCommand]
        private void SaveStickyNote(Window window)
        {
            StickyNote.Color = new BrushConverter().ConvertToString(Color)!;
            stickyNotes.Add(StickyNote);
            StickyNoteDataSaver.Save(stickyNotes, Settings.Path);
            window.DialogResult = true;
            window.Close();
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window.Close();
        }

        public NewTextStickyNoteViewModel()
        {
            stickyNotes = StickyNoteDataSaver.Load(Settings.Path);
        }
    }
}
