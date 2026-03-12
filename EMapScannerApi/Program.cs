using MacAddressVendorLookup;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace EMapScanner
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            List <(IPAddress, PhysicalAddress)> detectedAddresses = new List<(IPAddress, PhysicalAddress)>();
            MapScanner mapScanner = new MapScanner(detectedAddresses);

            var service = new MacLookupService();

            mapScanner.QuickScan();

            MacVendorInfo result;

            if (detectedAddresses.Count == 0)
            {
                Console.WriteLine("Не найдено активных устройств.");
            }
            else {
                string hostName;
                Console.WriteLine("Найдены устройства на следующих адресах:");
                foreach (var detectedAddress in detectedAddresses)
                {
                   
                    result = await service.LookupMacAddressAsync(detectedAddress.Item2.ToString());
                  
                    if (result != null)
                    {

                            Console.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, result.Company);
            
                                               
                    }
                    else
                    {
                        Console.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, "Unknown");
                    }                
                }
            }
     
        }


        //static async Task Main(string[] args)
        //{
        //    List<(IPAddress, PhysicalAddress)> detectedAddresses = new List<(IPAddress, PhysicalAddress)>();
        //    MapScanner mapScanner = new MapScanner(detectedAddresses);
        //    MacVendorInfo result;
        //    var service = new MacLookupService();

        //    mapScanner.QuickScan();


           
        //    Console.WriteLine();
        //    if (detectedAddresses.Count == 0)
        //    {
        //        Console.WriteLine("Не найдено активных устройств.");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Найдены устройства на следующих адресах:");
        //        foreach (var detectedAddress in detectedAddresses)
        //        {
                    
        //            string hostName;
           
        //            try
        //            {                           
        //                hostName = Dns.GetHostEntry(detectedAddress.Item1)?.HostName ?? "<Неизвестно>";                    
        //                result = await service.LookupMacAddressAsync(detectedAddress.Item2.ToString());                        
        //                Console.WriteLine(result.Company);
        //            }
        //            catch
        //            {
        //                hostName = "<Неизвестно>";
        //            }

        //            Console.WriteLine("- {0}: {1}: {2}:", detectedAddress.Item1, detectedAddress.Item2, hostName);
        //        }
        //    }
        //    Console.WriteLine();

        //    Console.WriteLine("Для выхода нажмите любую клавишу...");
        //    Console.ReadKey();
        //}
    }
}
