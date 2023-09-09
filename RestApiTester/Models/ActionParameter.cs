using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class ActionParameter:NotificationObject
    {
        private bool _DeleteS3File;

        public bool DeleteS3File
        {
            get
            {
                return _DeleteS3File;
            }
            set
            { 
                if (_DeleteS3File == value)
                {
                    return;
                }
                _DeleteS3File = value;
                RaisePropertyChanged();
            }
        }


        private string _DeleteS3Bucket;

        public string DeleteS3Bucket
        {
            get
            {
                return _DeleteS3Bucket;
            }
            set
            { 
                if (_DeleteS3Bucket == value)
                {
                    return;
                }
                _DeleteS3Bucket = value;
                RaisePropertyChanged();
            }
        }


        private string _DeleteS3Key;

        public string DeleteS3Key
        {
            get
            {
                return _DeleteS3Key;
            }
            set
            { 
                if (_DeleteS3Key == value)
                {
                    return;
                }
                _DeleteS3Key = value;
                RaisePropertyChanged();
            }
        }

        private bool _ShowS3File;

        public bool ShowS3File
        {
            get
            {
                return _ShowS3File;
            }
            set
            { 
                if (_ShowS3File == value)
                {
                    return;
                }
                _ShowS3File = value;
                RaisePropertyChanged();
            }
        }


        private string _ShowS3Bucket;

        public string ShowS3Bucket
        {
            get
            {
                return _ShowS3Bucket;
            }
            set
            { 
                if (_ShowS3Bucket == value)
                {
                    return;
                }
                _ShowS3Bucket = value;
                RaisePropertyChanged();
            }
        }


        private string _ShowS3Key;

        public string ShowS3Key
        {
            get
            {
                return _ShowS3Key;
            }
            set
            { 
                if (_ShowS3Key == value)
                {
                    return;
                }
                _ShowS3Key = value;
                RaisePropertyChanged();
            }
        }

    }
}
