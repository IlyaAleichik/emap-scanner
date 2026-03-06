using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EMapScanner
{
    public class MacVendorInfo
    {
        public string StartHex { get; set; }
        public string EndHex { get; set; }
        public long StartDec { get; set; }
        public long EndDec { get; set; }
        public string Company { get; set; }
        public string AddressL1 { get; set; }
        public string AddressL2 { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
    }

    public class MacLookupService
    {
        private readonly HttpClient _httpClient;

        public MacLookupService()
        {
            _httpClient = new HttpClient();
            // Рекомендуется добавить заголовок User-Agent для вежливости
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "YourAppName/1.0");
        }


        public async Task<MacVendorInfo> LookupMacAddressAsync(string macAddress)
        {
            // Очистим MAC от возможных разделителей (двоеточий, тире) и переведем в верхний регистр
            string cleanMac = macAddress.Replace(":", "").Replace("-", "").ToUpperInvariant();

            // Формируем URL. ВАЖНО: В исходном запросе были лишние символы.
            // Правильный формат: https://www.macvendorlookup.com/api/v2/30B5C2C022D4
            string url = $"https://www.macvendorlookup.com/api/v2/{cleanMac}";

            try
            {
                // Отправляем GET-запрос и автоматически десериализуем ответ в список
                // API возвращает массив, даже если он содержит один элемент.
                var vendorInfoList = await _httpClient.GetFromJsonAsync<List<MacVendorInfo>>(url);

                // Возвращаем первый элемент списка или null, если список пуст
                return vendorInfoList?.Count > 0 ? vendorInfoList[0] : null;
            }
            catch (HttpRequestException ex)
            {
                // Обработка ошибок сети или HTTP (например, 404 Not Found)
                Console.WriteLine($"Ошибка HTTP запроса: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Обработка других ошибок (например, десериализации)
                //Console.WriteLine($"Общая ошибка: {ex.Message}");
                return null;
            }
        }
    }
}
