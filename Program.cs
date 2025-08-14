
using System.Reflection;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static HttpClient client = new HttpClient();
    public static string uri = "https://brasilapi.com.br/api";
    public static Program program = new Program();
    public static Dictionary<string, string> apiEndpoints = new Dictionary<string, string>
    {
        { "CNPJ", "/cnpj/v1/" },
        { "CEP", "/cep/v1/" },
        { "DDD", "/ddd/v1/" },
        { "Bancos", "/bancos/v1/" },
        { "Banco", "/banco/v1/" }
    };


    private static async Task Main(string[] args)
    {
        displayMenu();
    }

    public async void getCNPJData()
    {
        string federalDocument = "";
        try
        {
            Console.Write("Digite o CNPJ (somente números):");
            federalDocument = Console.ReadLine()!; // ! is used to suppress null warning
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            using HttpResponseMessage response = await client.GetAsync($"{uri}{apiEndpoints["CNPJ"]}{federalDocument}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                CnpjResponse cnpj = JsonSerializer.Deserialize<CnpjResponse>(responseContent)!; // ! is used to suppress null warning
                PrintProperties(cnpj);
            }
            else
            {
                Console.WriteLine($"Erro {response.StatusCode}: {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }

    public static void displayMenu()
    {
        int userInput;
        Console.WriteLine("Central de APIs do Germano");
        Console.WriteLine("1. Consultar CNPJ");
        Console.WriteLine("2. Consultar CEP");
        Console.WriteLine("3. Consultar DDD");
        Console.WriteLine("4. Consultar lista de bancos");
        Console.WriteLine("5. Consultar banco");
        Console.WriteLine("============================");
        Console.Write("Digite a opção desejada: ");
        while (true)
        {
            try
            {
                userInput = int.Parse(Console.ReadLine()!); // ! is used to suppress null warning
                Console.Clear();
                switch (userInput)
                {
                    case 1:
                        program.getCNPJData();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public static void PrintProperties(object obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Objeto nulo!");
            return;
        }

        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj, null);
            Console.WriteLine($"{prop.Name}: {value}");
        }
    }
}