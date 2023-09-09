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
    public class ActionBoxViewModel : ViewModelBase
    {
        public ActionBoxViewModel(MainWindowViewModel parent) : base(parent)
        {
        }
        public ActionParameter Parameter
        {
            get
            {
                return this.Parent.Parameter.ActionParameter;
            }
        }
    }
}
