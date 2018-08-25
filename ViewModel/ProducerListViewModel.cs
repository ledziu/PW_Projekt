using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Sledz.Guitars.InterFaces;
using Sledz.Guitars.Core;

namespace Sledz.Guitars.Wpf.ViewModels
{
    public class ProducerListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers { get; set; } = new ObservableCollection<ProducerViewModel>();
        public ObservableCollection<IProducer> ProducersSelectList { get; set; } = new ObservableCollection<IProducer>();


        private ListCollectionView _view;
        public List<CountryName> countryNames { get; } = new List<CountryName>();

        public ProducerListViewModel()
        {
            GetAllProducers();
            GetAllCountries();
            _selectedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
            _editedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Producers);
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer(),param => this.CanAddNewProducer());
            _deleteProducerCommand = new RelayCommand(param => this.DeleteProducer());
            _editProducerCommand = new RelayCommand(param => this.EditProducer(),param => this.CanEditProducer());
            _addedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
            _addedProducer.Validate();


        }

        private void GetAllProducers()
        {
            foreach (var producer in BLogic.Blogic.GetAllProducers())
            {
                Producers.Add(new ProducerViewModel(producer));
                ProducersSelectList.Add(producer);
            }
        }
        private ProducerViewModel _editedProducer;
        public ProducerViewModel EditedProducer
        {
            get => _editedProducer;
            set
            {
                _editedProducer = value;
                OnPropertyChanged(nameof(EditedProducer));
            }
        }
        private ProducerViewModel _selectedProducer;
        public ProducerViewModel SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _editedProducer.Name = value.Name;
                _editedProducer.Country = value.Country;
                _editedProducer.Manufactures = value.Manufactures;
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        private void AddNewProducer()
        {
            if (BLogic.Blogic.AddProducer(AddedProducer.GetProducer()))
            {
                Producers.Add(AddedProducer);
                AddedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
                AddedProducer.Validate();

            }
            else
            {
                MessageBox.Show("Producer Already Exisits", "Producer Exisits");
            }
        }
        private RelayCommand _addNewProducerCommand;
        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;

        }
        private void DeleteProducer()
        {
            if (SelectedProducer.Name != null)
            {
                string messageText = $"Delete {SelectedProducer.Name}";
                MessageBoxResult res = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    if (BLogic.Blogic.DeleteProducer(SelectedProducer.GetProducer()))
                    {
                        ProducersSelectList.Remove(SelectedProducer.GetProducer());
                        Producers.Remove(SelectedProducer);
                    }
                    SelectedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
                }
            }
        }
       
        private RelayCommand _deleteProducerCommand;
        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }
        private void GetAllCountries()
        {
            foreach (CountryName country in Enum.GetValues(typeof(CountryName)))
            {
                countryNames.Add(country);
            }
        }
        private RelayCommand _editProducerCommand;
        public RelayCommand EditProducerCommand
        {
            get => _editProducerCommand;
        }
        private void EditProducer()
        {
            if (EditedProducer.Name != null)
            {
                string messageText = $"Edit {EditedProducer.Name}";
                MessageBoxResult res = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    BLogic.Blogic.UpdateProducer(EditedProducer.GetProducer());
                }
            }
            else {MessageBox.Show("e"); }
        }
        private bool CanAddNewProducer()
        {
            return !AddedProducer.HasErrors;
        }
        private bool CanEditProducer()
        {
            return !EditedProducer.HasErrors;
        }
        private ProducerViewModel _addedProducer;
        public ProducerViewModel AddedProducer
        {
            get => _addedProducer;
            set
            {
                _addedProducer = value;
                OnPropertyChanged(nameof(AddedProducer));
            }
        }
    }

}
