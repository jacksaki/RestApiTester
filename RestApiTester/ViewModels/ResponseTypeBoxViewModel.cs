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
    public class ResponseTypeBoxViewModel : ViewModelBase
    {
        public ResponseTypeBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
            this.SourceDocument.TextChanged += (sender, e) =>
            {
                this.Parameter.Source = this.SourceDocument.Text;
            };
        }
        public ResponseTypeParameter Parameter
        {
            get
            {
                return this.Parent.Parameter.ResponseTypeParameter;
            }
        }
        public ICSharpCode.AvalonEdit.Document.TextDocument SourceDocument
        {
            get;
        } = new ICSharpCode.AvalonEdit.Document.TextDocument();
    }
}
