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
    public class ResponseBoxViewModel : ViewModelBase
    {
        public ResponseBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }

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
                this.ResponseRawDocument.Text = value?.RawContent;
                RaisePropertyChanged();
            }
        }

        public ICSharpCode.AvalonEdit.Document.TextDocument ResponseRawDocument
        {
            get;
        } = new ICSharpCode.AvalonEdit.Document.TextDocument();
    }
}
