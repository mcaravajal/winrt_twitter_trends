// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Twitter_Tools.Services;
using Trend_Tools.Common;

namespace Trend_Tools.Services
{
    #region Trend
    [DataContract]
    public class Trend : BindableBase
    {
        private TwitterResults _TwitResults;
        public TwitterResults TwitResults {
            get
            {
                return _TwitResults;
            }
            set
            {
                _TwitResults = value;
                Twits = _TwitResults.results;
                this.SetProperty(ref this._TwitResults, value);
            }
        }
        private string _name;
        [DataMember]
        public string name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                this.SetProperty(ref this._name, value);
            }
        }
        private string _Header;
        [DataMember]
        public string Header
        {
            get
            {
                return _Header;
            }
            set
            {
                _Header = value;
                this.SetProperty(ref this._Header, value);
            }
        }
        private int _trend_index;
        [DataMember]
        public int trend_index { 
            get
            {
                return _trend_index;
            }
            set
            {
                _trend_index = value;
                this.SetProperty(ref this._trend_index, value);
            }
        }

        private string _place_name;
        [DataMember]
        public string place_name
        {
            get
            {
                return _place_name;
            }
            set
            {
                _place_name = value;
                this.SetProperty(ref this._place_name, value);
            }
        }


        private string _slug;
        [DataMember]
        public string slug
        {
            get
            {
                return _slug;
            }
            set
            {
                _slug = value;
                this.SetProperty(ref this._slug, value);
            }
        }

        private string _TittleTrend;
        [DataMember]
        public string TittleTrend
        {
            get
            {
                return _TittleTrend;
            }
            set
            {
                _TittleTrend = value;
                this.SetProperty(ref this._TittleTrend, value);
            }
        }

        public bool exist(List<Trend> obj)
        {
            foreach (Trend x in obj)
            {
                    if (x.slug==this.slug && x.TwitResults.page==this.TwitResults.page && x.name==this.name)
                    {
                        return true;
                    }
            }
            return false;
        }
        public Trend Find(List<Trend> obj)
        {
            foreach (Trend x in obj)
            {
                if (x.slug==this.slug && x.TwitResults.page==this.TwitResults.page)
                {
                    return x;
                }
            }
            return null;
        }
        
        private ObservableCollection<Twit> _Twits;
        public ObservableCollection<Twit> Twits
        {
            get { return _Twits; }
            set
            {
                if (_Twits!=value)
                {
                    _Twits = value;
                    this.SetProperty(ref this._Twits, value);
                }
            }
        }
        #region Property Changed
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
#endregion
    #region Results
    [DataContract]
    public class TrendsResults
    {
        private Trend[] _trends;
        [DataMember]
        public Trend[] trends
        {
            get
            {
                return _trends;
            }
            set
            {
                _trends = value;
                
            }
        }

        
        
    }
    #endregion
}
