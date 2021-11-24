using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OffscoreApp.Refrences.Controls
{
    public class CustomDate : DatePicker
    {
        public static readonly BindableProperty EnterTextProperty = BindableProperty.Create(propertyName: "Placeholder", returnType: typeof(string), declaringType: typeof(CustomDate), defaultValue: default(string));
        public string Placeholder
        {
            get;
            set;
        }
    }
}
