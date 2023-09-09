using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.ViewModels
{
    public abstract class ViewModelBase:ViewModel
    {
        public delegate void ErrorOccurredEventHandler(object sender, ErrorOccurredEventArgs e);
        public event ErrorOccurredEventHandler ErrorOccurred = delegate { };
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event MessageEventHandler Message = delegate { };

        public ViewModelBase(MainWindowViewModel parent) : base()
        {
            this.Parent = parent;
            
        }
        protected void OnError(ErrorOccurredEventArgs e)
        {
            this.ErrorOccurred(this, e);
        }
        protected void OnMessage(MessageEventArgs e)
        {
            this.Message(this, e);
        }
        public MainWindowViewModel Parent
        {
            get;
        }
    }
}
