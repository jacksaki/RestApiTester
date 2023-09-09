using Livet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestApiTester.Models
{
    public class RequestParameter:NotificationObject
    {
        public RequestParameter()
        {
            this.ActionParameter = new ActionParameter();
            this.Url = "http://localhost:3000/template";
            this.QueryStrings = new ObservableCollection<QueryStringItem>();
            this.QueryStrings.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (QueryStringItem item in e.OldItems)
                    {
                        item.PropertyChanged -= Item_PropertyChanged;
                    }
                }
                if (e.NewItems != null)
                {
                    foreach (QueryStringItem item in e.NewItems)
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                }
            };
        }
        public ActionParameter ActionParameter
        {
            get;
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(QueryStrings));
        }

        internal string GetUrl()
        {
            if (this.QueryStrings.Any())
            {
                return this.Url + string.Join("&", this.QueryStrings.Select(x => $"{x.Key}={x.Value}"));
            }
            else
            {
                return this.Url;
            }
        }

        private RequestMethod _RequestMethod;

        public RequestMethod RequestMethod
        {
            get
            {
                return _RequestMethod;
            }
            set
            { 
                if (_RequestMethod == value)
                {
                    return;
                }
                _RequestMethod = value;
                RaisePropertyChanged();
            }
        }

        private string _Url;

        public string Url
        {
            get
            {
                return _Url;
            }
            set
            { 
                if (_Url == value)
                {
                    return;
                }
                _Url = value;
                RaisePropertyChanged();
            }
        }

        public ResponseTypeParameter ResponseTypeParameter
        {
            get;
        } = new ResponseTypeParameter();

        private string _RequestJson;

        public string RequestJson
        {
            get
            {
                return _RequestJson;
            }
            set
            { 
                if (_RequestJson == value)
                {
                    return;
                }
                _RequestJson = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<QueryStringItem> QueryStrings
        {
            get;
        }

        public async Task< Type> GetResponseTypeAsync()
        {
            var sc = new CSharpScriptEvaluator();
            return await sc.GetResponseTypeAsync(this.ResponseTypeParameter);
        }

        public StringContent GetContent()
        {
            var jsonString = JsonConvert.SerializeObject(this.QueryStrings.ToDictionary(x => x.Key, y => y.Value));
            return new StringContent(jsonString, Encoding.UTF8, @"application/json");
        }

        internal void Validate()
        {
            if (!this.Url.StartsWith("https://") && !this.Url.StartsWith("http://"))
            {
                throw new ArgumentException("Url is too short.");
            }
            if(this.QueryStrings.Where(x=>string.IsNullOrWhiteSpace(x.Key)).Any())
            {
                throw new ArgumentException("QueryString key is empty.");
            }
        }
    }
}
