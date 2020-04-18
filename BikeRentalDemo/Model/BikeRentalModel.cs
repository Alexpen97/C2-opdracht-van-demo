using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BikeRentalDemo.Model
{
    /* Een class waar we alle INotifyPropertyChanged troep in verstoppen
     * zodat dat niet in iedere Class opnieuw neergezet hoeft te worden
     */
    public class BikeRentalModel : INotifyPropertyChanged
    {
        private BikeRentalDBModel db = new BikeRentalDBModel();
        public event PropertyChangedEventHandler PropertyChanged;

        /* Een iets andere versie dan we in het college hebben gemaakt:
         * deze versie gebruikt [CallerMemberName] om zelf alvast de propertyname in te vullen, zodat
         * we gewoon Notify() kunnen gebruiken ipv Notify("Address") ofzo.
         * We kunnen die default nog steeds overrulen, bijvoorbeeld bij MaxCapacity waar we expliciet
         * ook SpaceLeft willen Notify-en
         * https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=netframework-4.8
         */
        public void Notify([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
