using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class ResponseTypeParameter:NotificationObject
    {
        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrWhiteSpace(this.Source);
            }
        }
        private string _Name;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            { 
                if (_Name == value)
                {
                    return;
                }
                _Name = value;
                RaisePropertyChanged();
            }
        }


        private string _Source;

        public string Source
        {
            get
            {
                return _Source;
            }
            set
            { 
                if (_Source == value)
                {
                    return;
                }
                _Source = value;
                RaisePropertyChanged();
            }
        }

    }
}
