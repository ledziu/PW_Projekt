using System.Collections.ObjectModel;
using Sledz.Guitars.BLogic;
using System.Windows.Data;
using System.Windows;
using Sledz.Guitars.Core;
using System.Collections.Generic;
using System;

namespace Sledz.Guitars.Wpf.ViewModels
{
    public class GuitarListViewModel : ViewModelBase
    {
        public ObservableCollection<GuitarViewModel> Guitars { get; set; } = new ObservableCollection<GuitarViewModel>();

        private ListCollectionView _view;
        public GuitarListViewModel()
        {
            GetAllGuitars();

            _editedGuitar = new GuitarViewModel(Blogic.NewGuitar());
            _selectedGuitar = new GuitarViewModel(Blogic.NewGuitar());
            _addedGuitar = new GuitarViewModel(Blogic.NewGuitar());
            _addedGuitar.Validate();
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Guitars);
            _addNewGuiatCommand = new RelayCommand(param => this.AddNewGuitar(), param => this.CanAddNewGuitar());
            _deleteGuitarCommand = new RelayCommand(param => this.DeleteGuitar());
            _editGuitarCommand = new RelayCommand(param => this.EditGuitar(), param => this.CanEditGuitar());
        }
        private void GetAllGuitars()
        {
            foreach (var guitar in Blogic.GetAllGuitars())
            {
                Guitars.Add(new GuitarViewModel(guitar));
            }
        }
        
        private GuitarViewModel _editedGuitar;
        public GuitarViewModel EditedGuitar
        {
            get => _editedGuitar;
            set
            {
                _editedGuitar = value;
                OnPropertyChanged(nameof(EditedGuitar));
            }
        }
        private GuitarViewModel _selectedGuitar;
        public GuitarViewModel SelectedGuitar
        {
            get => _selectedGuitar;
            set
            {
                _editedGuitar.Producer = value.Producer;
                _editedGuitar.Model = value.Model;
                _editedGuitar.Strings = value.Strings;
                _editedGuitar.Color = value.Color;
                _selectedGuitar = value;
                OnPropertyChanged(nameof(SelectedGuitar));
            }
        }
        private GuitarViewModel _addedGuitar;
        public GuitarViewModel AddedGuitar
        {
            get => _addedGuitar;
            set
            {
                _addedGuitar = value;
                OnPropertyChanged(nameof(AddedGuitar));
            }
        }
        private void AddNewGuitar()
        {
            if (BLogic.Blogic.AddGuitar(AddedGuitar.GetGuitar()))
            {
                Guitars.Add(EditedGuitar);
                AddedGuitar = new GuitarViewModel(Blogic.NewGuitar());
                MessageBox.Show("New guitar", "New guitar");
                AddedGuitar.Validate();
            }
            else
            {
                MessageBox.Show("Failed guitar", "Failed guitar");
            }
        }
        private RelayCommand _addNewGuiatCommand;
        public RelayCommand AddNewGuitarCommand
        {
            get => _addNewGuiatCommand;
        }
        private RelayCommand _deleteGuitarCommand;
        public RelayCommand DeleteGuitarCommand
        {
            get => _deleteGuitarCommand;
        }
        public ListCollectionView View { get => _view; set => _view = value; }

        private void DeleteGuitar()
        {
            if (SelectedGuitar.Model != null && SelectedGuitar.Producer != null)
            {
                string messageText = $"Delete {SelectedGuitar.Producer.Name} {SelectedGuitar.Model} {SelectedGuitar.Strings}";
                MessageBoxResult res = MessageBox.Show(messageText, "Yes", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    if (BLogic.Blogic.DeleteGuitar(SelectedGuitar.GetGuitar()))
                    {
                        Guitars.Remove(SelectedGuitar);
                    }
                    SelectedGuitar = new GuitarViewModel(Blogic.NewGuitar());
                }
            }
        }
        private RelayCommand _editGuitarCommand;
        public RelayCommand EditGuitarCommand
        {
            get => _editGuitarCommand;
        }
        private void EditGuitar()
        {
            if (EditedGuitar.Model != null && EditedGuitar.Producer != null) {
                string messageText = $"Do you want to edit {EditedGuitar.Producer.Name} {EditedGuitar.Model}";
                MessageBoxResult res = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    Blogic.UpdateGuitar(EditedGuitar.GetGuitar());
                }
            }
        }
        
        private bool CanAddNewGuitar()
        {
            return !AddedGuitar.HasErrors;
        }
        private bool CanEditGuitar()
        {
            return !EditedGuitar.HasErrors;
        }
    }
}
