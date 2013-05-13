using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trend_Tools.Services;
using Twitter_Tools.Services;
using Windows.UI.Xaml;

namespace Trend_Tools.ViewModel
{
    public class TopTrendsViewModel : INotifyPropertyChanged
    {
        #region Trends
        private List<Trend> _trends;
        public List<Trend> trends {
            get
            {
                return _trends;
            }
            set
            {
                _trends = value;
                OnPropertyChanged("Toptrends");
            }
        }
        public List<Trend> GlobalTrends;
        #endregion
        #region IsLoading
        private bool _IsLoading;
        public bool IsLoading {
            get
            {
                return _IsLoading;
            }
            set
            {
                _IsLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        #endregion
        public TopTrendsViewModel()
        {
            if (trends == null && GlobalTrends == null)
            {
                trends = new List<Trend>();
                IsLoading = true;
                ApiTrendService.GetTrends(
                    (results) =>
                    {
                            foreach (Trend x in results)
                            {
                                if (x.slug == null)
                                {
                                    x.slug = WebUtility.UrlEncode(x.name);
                                    x.TittleTrend = x.name;
                                    x.Header = x.trend_index.ToString();
                                }
                                trends.Add(x);
                            }
                    },
                    (ex) =>
                    {
                        IsLoading = false;
                    },
                    () =>
                    {
                        IsLoading = false;
                    });
            }
            else
            {
                if (GlobalTrends != null)
                    trends = GlobalTrends;

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string Property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Property));
        }
    }
}
