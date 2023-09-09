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
    public class ResponseInfoBoxViewModel : ViewModelBase
    {
        public ResponseInfoBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
            this.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals(nameof(Response)))
                {
                    this.ResponseDocument.Text = this.Response?.ValueText;
                }
            };
        }
        public ICSharpCode.AvalonEdit.Document.TextDocument ResponseDocument
        {
            get;
        } = new ICSharpCode.AvalonEdit.Document.TextDocument();

        private ApiResponse _Response;

        public ApiResponse Response
        {
            get
            {
                return _Response;
            }
            set
            { 
                if (_Response == value)
                {
                    return;
                }
                _Response = value;
                RaisePropertyChanged();
            }
        }

    }
}
