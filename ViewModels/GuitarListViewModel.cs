using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sledz.Guitars.Core;
using Sledz.Guitars.InterFaces;
using System.Windows;
using System.Text;
using System.Windows.Data;
using Sledz.Guitars.BLogic;
using Sledz.Guitars.DAO;

namespace Sledz.Guitars.ViewModels
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
            _view = (ListCollectionView) CollectionViewSource.GetDefaultView(Guitars);
            _addNewGuiatCommand = new RelayCommand(param => this.AddNewGuitar());
            _deleteGuitarCommand = new RelayCommand(param => this.DeleteGuitar());

            
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
                _selectedGuitar = value;
                OnPropertyChanged(nameof(SelectedGuitar));
            }
        }
        private void AddNewGuitar()
        {
           if (BLogic.Blogic.AddGuitar(EditedGuitar.GetGuitar())){
                Guitars.Add(EditedGuitar);
                EditedGuitar = new GuitarViewModel(Blogic.NewGuitar());
            }
        }
        private RelayCommand _addNewGuiatCommand;
        public RelayCommand AddNewGuitarCommand
        {
            get => _addNewGuiatCommand;
        }
        private RelayCommand _deleteGuitarCommand;
        private RelayCommand DeleteGuitarCommand
        {
            get => _deleteGuitarCommand;
        }
        private void DeleteGuitar()
        {
            if(SelectedGuitar.Model != null && SelectedGuitar.Producer != null)
            {
                string messageText = $"Delete {SelectedGuitar.Producer.Name} {SelectedGuitar.Model} {SelectedGuitar.Strings}";
                MessageBoxResult res = MessageBox.Show(messageText, "Yes", MessageBoxButton.YesNo);
                if(res == MessageBoxResult.Yes)
                {
                    if (BLogic.Blogic.DeleteGuitar(SelectedGuitar.GetGuitar()))
                    {
                        Guitars.Remove(SelectedGuitar);
                    }
                    SelectedGuitar = new GuitarViewModel(Blogic.NewGuitar());
                }
            }
        }

    }
}
