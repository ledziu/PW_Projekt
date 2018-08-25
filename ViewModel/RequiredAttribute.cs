using System;

namespace Sledz.Guitars.Wpf.ViewModels
{
    internal class RequiredAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}