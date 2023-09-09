using Livet;
using Livet.Commands;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.Messaging.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace RestApiTester.ViewModels
{
    public class RequestBodyBoxViewModel : ViewModelBase
    {
        public RequestBodyBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
            this.RequestBodyDocument.TextChanged += (sender, e) =>
            {
                this.Parent.Parameter.RequestJson = this.RequestBodyDocument.Text;
            };
        }
        public ICSharpCode.AvalonEdit.Document.TextDocument RequestBodyDocument
        {
            get;
        } = new ICSharpCode.AvalonEdit.Document.TextDocument();
    }
}
