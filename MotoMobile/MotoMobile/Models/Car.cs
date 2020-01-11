using System;
using System.Collections.Generic;
using System.Text;

namespace MotoMobile.Models
{
    public class Car
    {
        public string Make { get; }

        public string Model { get; }

        public short Year { get; }

        public string ListModel
        {
            get
            {
                return $"{Model} {Year}";
            }
        }

        public Car(string make, string model, short year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
    }
}
