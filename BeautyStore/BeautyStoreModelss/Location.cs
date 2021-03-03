
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyStore.BeautyStoreModels
{
    public class Location
    {
        private int locationId;
        private string address;
        private string locationName;
        public int LocationId {
            get
            {
                return locationId;
            }
            set
            {
                if (value.Equals(null))
                { throw new System.Exception(); }
                locationId = value;
            }
        }
        public string Address {
            get
            {
                return address;
            }
            set
            {
                if (value.Equals(null))
                { throw new System.Exception(); }
                address = value;
            }
        }
        public string LocationName {
            get
            {
                return locationName;
            }
            set
            {
                if (value.Equals(null))
                { throw new System.Exception(); }
                locationName = value;
            }
        }
        public override string ToString()
        {
            return $"Location: {LocationName}\n\t ID:{LocationId}  Address: {Address}";
        }
    }
}
