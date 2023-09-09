using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class ScreenshotParameter:NotificationObject
    {

        private float _Ratio;

        public float Ratio
        {
            get
            {
                return _Ratio;
            }
            set
            { 
                if (_Ratio == value)
                {
                    return;
                }
                _Ratio = value;
                RaisePropertyChanged();
            }
        }

    }
}
