using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using HechtCommunity.Annotations;
using HechtCommunity.Services;
using HechtCommunity.Services.Impl;
using Xamarin.Forms;

namespace HechtCommunity
{
    public class CoworkingViewModel : INotifyPropertyChanged
    {
        private readonly CoworkingService _coworkingService;

        public CoworkingViewModel()
        {
            _coworkingService = new CoworkingService();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TableOneBtnClicked
        {
            get
            {
                return new Command(async () => {
                    if (await _coworkingService.IsTableVacant(1))
                    {
                        await _coworkingService.BookTableById(1);
                        TableOneColor = Color.Crimson;
                    }
                    else
                    {
                        await _coworkingService.UnbookTableById(1);
                        TableOneColor = Color.FromHex("#0e5139");
                    }
                });
            }
        }

        private Color _tableOneColor = Color.FromHex("#0e5139");
        //private Color _tableOneColor = Color.Tomato;
        public Color TableOneColor
        {
            get { return _tableOneColor; }
            set
            {
                if (value == _tableOneColor)
                    return;

                _tableOneColor = value;
                OnPropertyChanged(nameof(TableOneColor));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
