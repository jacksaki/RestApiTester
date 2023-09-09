using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.ViewModels
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message) : this(string.Empty, message)
        {
        }
        public MessageEventArgs(string title, string message)
        {
            this.Title = title;
            this.Message = message;
        }
        public string Title
        {
            get;
        }
        public string Message
        {
            get;
        }
    }
}
