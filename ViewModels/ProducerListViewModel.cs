using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Sledz.Guitars.InterFaces;

namespace Sledz.Guitars.ViewModels
{
    public class ProducerListViewModel : ViewModelBase
    {
        public ObservableCollection<ProducerViewModel> Producers { get; set; } = new ObservableCollection<ProducerViewModel>();
        public ObservableCollection<IProducer> ProducersSelectList { get; set; } = new ObservableCollection<IProducer>();

        private ListCollectionView _view;

        public ProducerListViewModel()
        {
            GetAllProducers();
            _selectedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
            _editedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
          //  _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Producers);
            _addNewProducerCommand = new RelayCommand(param => this.AddNewProducer());
            _deleteProducerCommand = new RelayCommand(param => this.DeleteProducer());


        }

        private void GetAllProducers()
        {
            foreach(var producer in BLogic.Blogic.GetAllProducers())
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
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }
        private void AddNewProducer()
        {
            if (BLogic.Blogic.AddProducer(EditedProducer.GetProducer()))
            {
                Producers.Add(EditedProducer);
                ProducersSelectList.Add(EditedProducer.GetProducer());
                EditedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());

            }
        }
        private RelayCommand _addNewProducerCommand;
        public RelayCommand AddNewProducerCommand
        {
            get => _addNewProducerCommand;
        }
        private void DeleteProducer()
        {
            string messageText = $"Delete {SelectedProducer.Name}";
            MessageBoxResult res = MessageBox.Show(messageText, "Confirm", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes)
            {
                if (BLogic.Blogic.DeleteProducer(SelectedProducer.GetProducer()))
                {
                    ProducersSelectList.Remove(SelectedProducer.GetProducer());
                    Producers.Remove(SelectedProducer);
                }
                SelectedProducer = new ProducerViewModel(BLogic.Blogic.NewProducer());
            }
        }
        private RelayCommand _deleteProducerCommand;
        public RelayCommand DeleteProducerCommand
        {
            get => _deleteProducerCommand;
        }
    }
   
}
