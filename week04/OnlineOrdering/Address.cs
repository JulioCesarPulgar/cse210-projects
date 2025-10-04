using System;

namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public string GetStreet() => _street;
        public string GetCity() => _city;
        public string GetStateOrProvince() => _stateOrProvince;
        public string GetCountry() => _country;

        public bool IsInUSA()
        {
            return string.Equals(_country?.Trim(), "USA", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(_country?.Trim(), "United States", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(_country?.Trim(), "United States of America", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFullAddress()
        {
            return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}
