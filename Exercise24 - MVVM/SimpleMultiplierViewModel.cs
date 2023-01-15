using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MVVM {
    class SimpleMultiplierViewModel : INotifyPropertyChanged {
        double multiplicand, multiplier, product;
        double addend1, addend2, addition;

        public event PropertyChangedEventHandler PropertyChanged;

        public double Multiplicand {
            set {
                if (multiplicand != value) {
                    multiplicand = value;
                    OnPropertyChanged("Multiplicand");
                    UpdateProduct();
                }
            }
            get {
                return multiplicand;
            }
        }

        public double Multiplier {
            set {
                if (multiplier != value) {
                    multiplier = value;
                    OnPropertyChanged("Multiplier");
                    UpdateProduct();
                }
            }
            get {
                return multiplier;
            }
        }

        public double Product {
            protected set {
                if (product != value) {
                    product = value;
                    OnPropertyChanged("Product");
                }
            }
            get {
                return product;
            }
        }

        public double Addend1
        {
            set
            {
                if (addend1 != value)
                {
                    addend1 = value;
                    OnPropertyChanged("Addend1");
                    UpdateAddition();
                }
            }
            get
            {
                return addend1;
            }
        }

        public double Addend2
        {
            set
            {
                if (addend2 != value)
                {
                    addend2 = value;
                    OnPropertyChanged("Addend2");
                    UpdateAddition();
                }
            }
            get
            {
                return addend2;
            }
        }

        public double Addition
        {
            protected set
            {
                if (addition != value)
                {
                    addition = value;
                    OnPropertyChanged("Addition");
                }
            }
            get
            {
                return addition;
            }
        }

        void UpdateAddition()
        {
            Addition = Addend1 + Addend2;
        }

        void UpdateProduct() {
            Product = Multiplicand * Multiplier;
        }

        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
