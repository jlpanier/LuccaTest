using Business;
using Lucca.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Lucca.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InitController : BaseController
    {
        public InitController(ILogger<InitController> logger, IConfiguration configuration):base(logger, configuration)
        {
        }

        [HttpPut]
        public ResponseCustomers Populate()
        {
            try
            {
                Devise.InsertOrUpdate("Afghani", "AFN", 971 );
                Devise.InsertOrUpdate("US Dollar", "USD", 840);
                Devise.InsertOrUpdate("Ruble Russe", "RUB", 643 );
                Devise.InsertOrUpdate("Rand", "ZAR", 710);
                Devise.InsertOrUpdate("Lek", "ALL", 8);
                Devise.InsertOrUpdate("Dinars algériens", "DZD", 12);
                Devise.InsertOrUpdate("Euro", "EUR", 978);
                Devise.InsertOrUpdate("Kwanza", "AOA",  973);
                Devise.InsertOrUpdate("Dollar des Caraïbes orientales", "XCD",951);
                Devise.InsertOrUpdate("Riyal Saoudiens", "SAR", 682);
                Devise.InsertOrUpdate("Peso Argentin", "ARS", 032);
                Devise.InsertOrUpdate("Dram Armenien", "AMD", 051);
                Devise.InsertOrUpdate("Aruban Florin", "AWG", 533);
                Devise.InsertOrUpdate("Australian Dollar", "AUD", 036);
                Devise.InsertOrUpdate("Azerbaijanian Manat", "AZN", 944);
                Devise.InsertOrUpdate("Dollar Bahaméen", "BSD", 044);
                Devise.InsertOrUpdate("Dinar Bahraini", "BHD", 048);
                Devise.InsertOrUpdate("Taka", "BDT", 050);
                Devise.InsertOrUpdate("Dollars Barbados", "BBD", 052);
                Devise.InsertOrUpdate("Dollar de Bélize", "BZD", 084);
                Devise.InsertOrUpdate("CFA Franc", "XOF", 952);
                Devise.InsertOrUpdate("Dollar Bermudien", "BMD", 060);
                Devise.InsertOrUpdate("Ngultrum", "BTN", 064);
                Devise.InsertOrUpdate("Indian Rupee Indienne", "INR", 356);
                Devise.InsertOrUpdate("Ruble Biélorusse", "BYR", 974);
                Devise.InsertOrUpdate("Mvdol", "BOV", 984);
                Devise.InsertOrUpdate("Boliviano", "BOB", 068);
                Devise.InsertOrUpdate("Mark Convertible", "BAM", 977);
                Devise.InsertOrUpdate("Pula", "BWP", 072);
                Devise.InsertOrUpdate("Couronne Norvégienne", "NOK", 578);
                Devise.InsertOrUpdate("Brunei Dollar", "BND",  096);
                Devise.InsertOrUpdate("Real Brésilien", "BRL",  986);
                Devise.InsertOrUpdate("Lev Bulgare", "BGN",  975);
                Devise.InsertOrUpdate("Franc CFA BCEAO", "XOF",  952);
                Devise.InsertOrUpdate("Franc Burundi", "BIF",  108);
                Devise.InsertOrUpdate("Cabo Verde Escudo", "CVE",  132);
                Devise.InsertOrUpdate("Riel", "KHR",  116);
                Devise.InsertOrUpdate("Franc CFA BEAC", "XAF",  950);
                Devise.InsertOrUpdate("Dollar Canadien", "CAD",  124);
                Devise.InsertOrUpdate("Cayman Islands Dollar", "KYD",  136);
                Devise.InsertOrUpdate("CFA Franc BEAC", "XAF",  950);
                Devise.InsertOrUpdate("Unidad de Fomento", "CLF",  990);
                Devise.InsertOrUpdate("Peso Chilien", "CLP",  152);
                Devise.InsertOrUpdate("Yuan Renminbi", "CNY",  156);
                Devise.InsertOrUpdate("Dollar Australien", "AUD",  036);
                Devise.InsertOrUpdate("Peso Colombien", "COP", 170);
                Devise.InsertOrUpdate("Unidad de Valor Real", "COU", 970);
                Devise.InsertOrUpdate("Franc Comorien", "KMF", 174);
                Devise.InsertOrUpdate("Le Franc Congolais", "CDF", 976);
                Devise.InsertOrUpdate("Franc CFA BEAC", "XAF", 950);
                Devise.InsertOrUpdate("Dollar Néo-Zélandais", "NZD", 554);
                Devise.InsertOrUpdate("Won", "KRW", 410);
                Devise.InsertOrUpdate("Won Nord-coréen", "KPW", 408);
                Devise.InsertOrUpdate("Costa Rican Colon", "CRC", 188);
                Devise.InsertOrUpdate("Kuna", "HRK", 191);
                Devise.InsertOrUpdate("Peso Convertible", "CUC", 931);
                Devise.InsertOrUpdate("Peso Cubain", "CUP", 192);
                Devise.InsertOrUpdate("Florin des Antilles néerlandaises", "ANG", 532);
                Devise.InsertOrUpdate("CFA Franc BCEAO", "XOF",	952);
                Devise.InsertOrUpdate("Couronne Danoise", "DKK", 208);
                Devise.InsertOrUpdate("Franc Djiboutien", "DJF", 262);
                Devise.InsertOrUpdate("Dollar des Caraïbes orientales", "XCD", 951);
                Devise.InsertOrUpdate("Pound Égyptien", "EGP", 818);
                Devise.InsertOrUpdate("Dollar US", "USD", 840);
                Devise.InsertOrUpdate("Nakfa", "ERN", 232);
                Devise.InsertOrUpdate("Birr Éthiopienne", "ETB", 230);
                Devise.InsertOrUpdate("Livre des Îles Malouines", "FKP", 238);
                Devise.InsertOrUpdate("Dollar des Fiji", "FJD", 242);
                Devise.InsertOrUpdate("SDR(Droit de tirage spécial)", "XDR", 960);
                Devise.InsertOrUpdate("Franc CFA BEAC", "XAF", 950);
                Devise.InsertOrUpdate("Dalasi", "GMD", 270);
                Devise.InsertOrUpdate("Lari", "GEL", 981);
                Devise.InsertOrUpdate("Cedi du Ghana", "GHS", 936);
                Devise.InsertOrUpdate("Pound de Gibraltar", "GIP", 292);
                Devise.InsertOrUpdate("Dollar des Caraïbes orientales", "XCD", 951);
                Devise.InsertOrUpdate("Couronne Danoise", "DKK", 208);
                Devise.InsertOrUpdate("Dollar US", "USD", 840);
                Devise.InsertOrUpdate("Quetzal", "GTQ", 320);
                Devise.InsertOrUpdate("Livre Sterlling", "GBP", 826);
                Devise.InsertOrUpdate("Franc Guinéen", "GNF", 324);
                Devise.InsertOrUpdate("Franc CFA BEAC", "XAF", 950);
                Devise.InsertOrUpdate("CFA Franc BCEAO", "XOF", 952);
                Devise.InsertOrUpdate("Dollar guyanien", "GYD", 328);
                Devise.InsertOrUpdate("Gourde", "HTG", 332);
                Devise.InsertOrUpdate("Lempira", "HNL", 340);
                Devise.InsertOrUpdate("Dollar de Hong Kong", "HKD", 344);
                Devise.InsertOrUpdate("Forint", "HUF", 348);
                Devise.InsertOrUpdate("Livre Sterlling", "GBP", 826);
                Devise.InsertOrUpdate("Dollar Australien", "AUD", 036);
                Devise.InsertOrUpdate("Couronne Danoise", "DKK", 208);
                Devise.InsertOrUpdate("Rupee Indienne", "INR", 356);
                Devise.InsertOrUpdate("Rupiah", "IDR", 360);
                Devise.InsertOrUpdate("Rial Iranien", "IRR",	364);
                Devise.InsertOrUpdate("Dinar Iraquien", "IQD", 368);
                Devise.InsertOrUpdate("Couronne Islandaise", "ISK", 352);
                Devise.InsertOrUpdate("Nouveau Sheqel Israélien", "ILS", 376);
                Devise.InsertOrUpdate("Dollars Jamaicain", "JMD", 388);
                Devise.InsertOrUpdate("Yen", "JPY", 392);
                Devise.InsertOrUpdate("Livre Sterlling", "GBP", 826);
                Devise.InsertOrUpdate("Dinars Jordanien", "JOD", 400);
                Devise.InsertOrUpdate("Tenge", "KZT", 398);
                Devise.InsertOrUpdate("Shilling Kenyan", "KES", 404);
                Devise.InsertOrUpdate("Som", "KGS", 417);
                Devise.InsertOrUpdate("Dollar Australien", "AUD", 036);
                Devise.InsertOrUpdate("Dinar Kowaitien", "KWD", 414);
                Devise.InsertOrUpdate("Kip", "LAK", 418);
                Devise.InsertOrUpdate("Le Colon Salvadorien", "SVC", 222);
                Devise.InsertOrUpdate("Loti", "LSL", 426);
                Devise.InsertOrUpdate("Rand", "ZAR", 710);
                Devise.InsertOrUpdate("Pound Libanais", "LBP", 422);
                Devise.InsertOrUpdate("Dollar du Liberia", "LRD", 430);
                Devise.InsertOrUpdate("Dinars Libien", "LYD", 434);
                Devise.InsertOrUpdate("Swiss Franc", "CHF", 756);
                Devise.InsertOrUpdate("Pataca", "MOP", 446);
                Devise.InsertOrUpdate("Denar", "MKD", 807);
                Devise.InsertOrUpdate("Malagasy Ariary", "MGA", 969);
                Devise.InsertOrUpdate("Kwacha", "MWK", 454);
                Devise.InsertOrUpdate("Ringgi Malaisien", "MYR", 458);
                Devise.InsertOrUpdate("Rufiyaa", "MVR", 462);
                Devise.InsertOrUpdate("CFA Franc BCEAO", "XOF", 952);
                Devise.InsertOrUpdate("Mauritius Rupee", "MUR", 480);
                Devise.InsertOrUpdate("Ouguiya", "MRO", 478);
                Devise.InsertOrUpdate("Peso Mexicain", "MXN", 484);
                Devise.InsertOrUpdate("Mexican Unidad de Inversion(UDI)", "MXV", 979);
                Devise.InsertOrUpdate("Leu Moldavien", "MDL", 498);
                Devise.InsertOrUpdate("Tugrik", "MNT", 496);
                Devise.InsertOrUpdate("Dollar des Caraïbes orientales", "XCD", 951);
                Devise.InsertOrUpdate("Dirham Marocain", "MAD", 504);
                Devise.InsertOrUpdate("Metical", "MZN", 943);
                Devise.InsertOrUpdate("Kyat", "MMK", 104);
                Devise.InsertOrUpdate("Dollar Namibien", "NAD", 516);
                Devise.InsertOrUpdate("Rand", "ZAR", 710);
                Devise.InsertOrUpdate("Dollar Australien", "AUD", 036);
                Devise.InsertOrUpdate("Cordoba", "NIO", 558);
                Devise.InsertOrUpdate("Franc CFA BCEAO", "XOF", 952);
                Devise.InsertOrUpdate("Naira", "NGN", 566);
                Devise.InsertOrUpdate("Dollar Néo - Zélandais", "NZD", 554);
                Devise.InsertOrUpdate("Couronne Norvégienne", "NOK", 578);
                Devise.InsertOrUpdate("Franc CFP", "XPF", 953);
                Devise.InsertOrUpdate("Néo - Zélandais", "NZD", 554);
                Devise.InsertOrUpdate("Rupee Népalais", "NPR", 524);
                Devise.InsertOrUpdate("Rial Omani", "OMR", 512);
                Devise.InsertOrUpdate("Shilling Ougandaisg", "UGX", 800);
                Devise.InsertOrUpdate("Sum d'Oubekistan", "UZS",	860);
                Devise.InsertOrUpdate("Rupee du Pakistan", "PKR", 586);
                Devise.InsertOrUpdate("Balboa", "PAB", 590);
                Devise.InsertOrUpdate("Kina", "PGK", 598);
                Devise.InsertOrUpdate("Guarani", "PYG", 600);
                Devise.InsertOrUpdate("Unité de compte de la BAD", "XUA", 965);
                Devise.InsertOrUpdate("Nouveau Sol", "PEN", 604);
                Devise.InsertOrUpdate("Peso Phillipins", "PHP", 608);
                Devise.InsertOrUpdate("Dollar Néo - Zélandais", "NZD", 554);
                Devise.InsertOrUpdate("Zloty", "PLN", 985);
                Devise.InsertOrUpdate("Franc CFP", "XPF", 953);
                Devise.InsertOrUpdate("Rial Qatari", "QAR", 634);
                Devise.InsertOrUpdate("Leu Roumain", "RON", 946);
                Devise.InsertOrUpdate("Livre Sterling", "GBP",	826);
                Devise.InsertOrUpdate("Ruble Russe", "RUB", 643);
                Devise.InsertOrUpdate("Franc Rwandais", "RWF", 646);
                Devise.InsertOrUpdate("Peso Dominicain", "DOP", 214);
                Devise.InsertOrUpdate("Couronne Tchèque", "CZK", 203);
                Devise.InsertOrUpdate("Dirham Maroccain", "MAD", 504);
                Devise.InsertOrUpdate("Dollar des Caraïbes orientales", "XCD", 951);
                Devise.InsertOrUpdate("Livre de Saint Helene", "SHP", 654);
                Devise.InsertOrUpdate("Tala", "WST", 882);
                Devise.InsertOrUpdate("Dobra", "STD", 678);
                Devise.InsertOrUpdate("Dinar Serbe", "RSD", 941);
                Devise.InsertOrUpdate("Rupee des Seychelles", "SCR", 690);
                Devise.InsertOrUpdate("Leone", "SLL", 694);
                Devise.InsertOrUpdate("Dollar Singaporien", "SGD", 702);
                Devise.InsertOrUpdate("Florin des Antilles néerlandaises", "ANG", 532);
                Devise.InsertOrUpdate("Sucre", "XSU", 994);
                Devise.InsertOrUpdate("Dollar des îles Solomon", "SBD", 090);
                Devise.InsertOrUpdate("Shilling Somalien", "SOS", 706);
                Devise.InsertOrUpdate("Livre Soudanais", "SDG", 938);
                Devise.InsertOrUpdate("Livre sud - soudanaise", "SSP", 728);
                Devise.InsertOrUpdate("Rupee Sri Lankais", "LKR", 144);
                Devise.InsertOrUpdate("Franc Suisse", "CHF", 756);
                Devise.InsertOrUpdate("Dollars du Surinam", "SRD", 968);
                Devise.InsertOrUpdate("Couronne Suédoise", "SEK", 752);
                Devise.InsertOrUpdate("Couronne Norvégienne", "NOK", 578);
                Devise.InsertOrUpdate("Lilangeni", "SZL", 748);
                Devise.InsertOrUpdate("Pound Syrien", "SYP", 760);
                Devise.InsertOrUpdate("Franc CFA", "XOF", 952);
                Devise.InsertOrUpdate("Somoni", "TJS", 972);
                Devise.InsertOrUpdate("Nouveau dollars Taiwanais", "TWD", 901);
                Devise.InsertOrUpdate("Shilling Tanzanien", "TZS", 834);
                Devise.InsertOrUpdate("CFA Franc", "XAF", 950);
                Devise.InsertOrUpdate("Baht", "THB", 764);
                Devise.InsertOrUpdate("Franc CFA BCEAO", "XOF", 952);
                Devise.InsertOrUpdate("Dollar néo - zélandais", "NZD", 554);
                Devise.InsertOrUpdate("Pa’anga", "TOP", 776);
                Devise.InsertOrUpdate("Dollars de Trinidad et Tobago", "TTD", 780);
                Devise.InsertOrUpdate("Dinars Tunisiens", "TND", 788);
                Devise.InsertOrUpdate("Turkménistan Nouveau Manat", "TMT", 934);
                Devise.InsertOrUpdate("Livre Turque", "TRY", 949);
                Devise.InsertOrUpdate("Dollars Australiens", "AUD", 036);
                Devise.InsertOrUpdate("Hryvnia", "UAH", 980);
                Devise.InsertOrUpdate("Dirham", "AED", 784);
                Devise.InsertOrUpdate("Peso en Unidades Indexadas", "UYI", 940);
                Devise.InsertOrUpdate("Peso Uruguayen", "UYU", 858);
                Devise.InsertOrUpdate("Vatu", "VUV", 548);
                Devise.InsertOrUpdate("Bolivar", "VEF", 937);
                Devise.InsertOrUpdate("Dong", "VND", 704);
                Devise.InsertOrUpdate("Franc CFP", "XPF", 953);
                Devise.InsertOrUpdate("Rial du Yemenl", "YER", 886);
                Devise.InsertOrUpdate("Kwacha Zambien", "ZMW", 967);
                Devise.InsertOrUpdate("Dollars du Zimbabwe", "ZWL", 932);
                Devise.InsertOrUpdate("Dollars US", "USD",	840);
                Devise.InsertOrUpdate("Dollars US (Prochain jours)", "USN",	997);
                Devise.InsertOrUpdate("Dollar Australien", "AUD",	036);

                Customer.InsertOrUpdate("Adolphe", "Tiers", "EUR");
                Customer.InsertOrUpdate("Patrice", "Mc Mahon", "EUR");
                Customer.InsertOrUpdate("Jules", "Grévy", "EUR");
                Customer.InsertOrUpdate("Sadi", "Carnot", "EUR");
                Customer.InsertOrUpdate("Jean", "Casimir-Perier", "EUR");
                Customer.InsertOrUpdate("Félix", "Faure", "EUR");
                Customer.InsertOrUpdate("Emile", "Loubet", "EUR");
                Customer.InsertOrUpdate("Armand", "Fallieres", "EUR");
                Customer.InsertOrUpdate("Raymond", "Poincaré", "EUR");
                Customer.InsertOrUpdate("Paul", "Deschanel", "EUR");
                Customer.InsertOrUpdate("Alexandre", "Millerand", "EUR");
                Customer.InsertOrUpdate("Gaston", "Doumergue", "EUR");
                Customer.InsertOrUpdate("Paul", "Doumer", "EUR");
                Customer.InsertOrUpdate("Albert", "Lebrun", "EUR");
                Customer.InsertOrUpdate("Vincent", "Auriol", "EUR");
                Customer.InsertOrUpdate("René", "Coty", "EUR");
                Customer.InsertOrUpdate("Alain", "Poher", "EUR");

                Customer.InsertOrUpdate("Anthony", "Stark", "USD");
                Customer.InsertOrUpdate("Natasha", "Romanova", "USD");

                var items = Customer.All();
                _logger.LogInformation($"Populate => {items.Count()} rows");
                return ResponseCustomers.SuccessResponse(_mode, items);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Populate => {ex.Message}");
                return ResponseCustomers.BadResponse(_mode, ex.Message);
            }
        }
    }
}