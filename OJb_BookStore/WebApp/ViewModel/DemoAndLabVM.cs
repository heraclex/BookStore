using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class DemoAndLabVM
    {
        public List<KeyValuePair<string, string>> ListDemo
        {
            get
            {
                return new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("0", "Zero"),
                        new KeyValuePair<string, string>("1", "One"),
                        new KeyValuePair<string, string>("2", "Two"),
                        new KeyValuePair<string, string>("3", "Three"),
                        new KeyValuePair<string, string>("4", "Four"),
                        new KeyValuePair<string, string>("5", "Five"),
                        new KeyValuePair<string, string>("6", "Six"),
                        new KeyValuePair<string, string>("7", "Seven"),
                        new KeyValuePair<string, string>("8", "Enght"),
                        new KeyValuePair<string, string>("9", "Night"),
                    };
            }
        }
    }
}