using System.Net;
using System.Net.NetworkInformation;
using ArpLookup;
using MacAddressVendorLookup;
namespace EMapScanner
{




    public class MapScanner
    {
        string addressBase = "192.168.0.";
        int startAddress = 1;
        int endAddress = 255;
        byte[] emptyPhysicalAddress = [0x00, 0x00, 0x00, 0x00, 0x00, 0x00];
        private List<(IPAddress, PhysicalAddress)> detectedAddresses;

        public MapScanner(List<(IPAddress, PhysicalAddress)> detectedAddresses)
        {
            this.detectedAddresses = detectedAddresses;
        }

        public void QuickScan()
        {
            // Сканируем последовательно адреса на доступность
            for (int addressPart = startAddress; addressPart <= endAddress; addressPart++)
            {
                string currentAddressAsString = $"{addressBase}{addressPart}";
                IPAddress currentAddress = IPAddress.Parse(currentAddressAsString);

                // Отправляем ARP-запрос для получения MAC-адреса.
                // Если MAC-адрес успешно получен, значит, узел в сети "живой"
                PhysicalAddress? physicalAddress;
                try
                {
                    physicalAddress = Arp.Lookup(currentAddress);

                    // Если получен пустой MAC-адрес,
                    // то присваиваем явно неопределенное значение
                    if (physicalAddress == null
                        || physicalAddress.GetAddressBytes().SequenceEqual(emptyPhysicalAddress)
                        || physicalAddress == PhysicalAddress.None)
                    {
                        physicalAddress = null;
                    }
                }
                catch
                {
                    physicalAddress = null;
                }

                // Отправляем ICMP-запрос с таймаутом в 1 секунду
                if (physicalAddress != null)
                {
                    detectedAddresses.Add(new ValueTuple<IPAddress, PhysicalAddress>(currentAddress, physicalAddress));
                    Console.WriteLine($"[{DateTime.Now}] {currentAddress}: {physicalAddress}");
                }
                else
                {
                    Console.WriteLine($"[{DateTime.Now}] {currentAddress}: <Не доступен>");
                }
            }

        }

        //public void GetVendorName()
        //{
        //    var vendorInfoProvider = new MacVendorBinaryReader();
        //    using (var resourceStream = MacAddressVendorLookup.ManufBinResource.GetStream().Result)
        //    {
        //        vendorInfoProvider.Init(resourceStream).Wait();
        //    }
        //    var addressMatcher = new MacAddressVendorLookup.AddressMatcher(vendorInfoProvider);
        //        var vendorInfo = addressMatcher.FindInfo(ni.GetPhysicalAddress());
        //        Console.WriteLine("\nAdapter: " + ni.Description);
        //}

        //List<(IPAddress, PhysicalAddress)> detectedAddresses = new List<(IPAddress, PhysicalAddress)>();

        //PhysicalAddress mac = Arp.Lookup(IPAddress.Parse("192.168.0.4"));

    }
}
