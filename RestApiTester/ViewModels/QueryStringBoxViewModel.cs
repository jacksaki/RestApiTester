using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using RestApiTester.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RestApiTester.ViewModels
{
    public class QueryStringBoxViewModel : ViewModelBase
    {
        public QueryStringBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }
        public RequestParameter Parameter
        {
            get
            {
                return this.Parent.Parameter;
            }
        }


        private QueryStringItem _SelectedQueryString;

        public QueryStringItem SelectedQueryString
        {
            get
            {
                return _SelectedQueryString;
            }
            set
            { 
                if (_SelectedQueryString == value)
                {
                    return;
                }
                _SelectedQueryString = value;
                RemoveSelectedCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }


        private ViewModelCommand _AddCommand;

        public ViewModelCommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new ViewModelCommand(Add);
                }
                return _AddCommand;
            }
        }

        public void Add()
        {
            this.Parameter.QueryStrings.Add(new QueryStringItem() { Key = "****", Value = "****" });
        }


        private ViewModelCommand _RemoveSelectedCommand;

        public ViewModelCommand RemoveSelectedCommand
        {
            get
            {
                if (_RemoveSelectedCommand == null)
                {
                    _RemoveSelectedCommand = new ViewModelCommand(RemoveSelected, CanRemoveSelected);
                }
                return _RemoveSelectedCommand;
            }
        }

        public bool CanRemoveSelected()
        {
            return this.SelectedQueryString != null;
        }

        public void RemoveSelected()
        {
            this.Parameter.QueryStrings.Remove(this.SelectedQueryString);
        }

    }
}
