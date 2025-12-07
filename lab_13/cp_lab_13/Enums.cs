using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cp_lab_13
{
    public enum ProductGroup
    {
        Books,
        CDs,
        DVDs,
        MobilePhones,
        Players,
        Accessories,
        Displays,
        Cases,
        PowerSupplies,
        Keyboards
    }

    public enum Providers
    {
        ProviderA,
        ProviderB,
        ProviderC,
        ProviderD
    }

    public enum Units
    {
        Piece,
        Box,
        Pack,
        Set
    }

    public enum Currency
    {
        USD,
        EUR,
        GBP,
        JPY
    }
}
