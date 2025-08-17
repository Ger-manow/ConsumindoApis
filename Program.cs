
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    public static Program program = new Program();
    private static HttpClient client = new HttpClient();
    private static string uri = "https://brasilapi.com.br/api";
    private static Dictionary<string, string> apiEndpoints = new Dictionary<string, string>
    {
        { "CNPJ", "/cnpj/v1/" },
        { "CEP", "/cep/v2/" },
        { "DDD", "/ddd/v1/" },
        { "Bancos", "/bancos/v1/" },
        { "Banco", "/banco/v1/" }
    };
    private static EmpresaContext db = new EmpresaContext();
    private static ILoggerFactory loggerFactory = new LoggerFactory();
    private static IMapper mapper;

    private static async Task Main(string[] args)
    {
        CreateMapper();
        displayMenu();
    }

    public static void displayMenu()
    {
        int userInput;
        Console.WriteLine("Central de APIs do Germano");
        Console.WriteLine("1. Consultar CNPJ na API");
        Console.WriteLine("2. Consultar CNPJ no db");
        Console.WriteLine("3. Consultar CEP");
        Console.WriteLine("4. Consultar DDD");
        Console.WriteLine("5. Consultar lista de bancos");
        Console.WriteLine("6. Consultar banco");
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
                        getCNPJData();
                        break;
                    case 2:
                        getCNPJDataFromDb();
                        break;
                    case 3:
                        getCep();
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

    // async serve para indicar que o método pode ser executado de forma assíncrona
    public static async void getCNPJData()
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
                CnpjResponseDTO cnpj = JsonSerializer.Deserialize<CnpjResponseDTO>(responseContent)!; // ! is used to suppress null warning
                PropertyPrinter.PrintProperties(cnpj);
                Empresa empresa = mapper.Map<Empresa>(cnpj);
                db.Add(empresa);
                db.SaveChangesAsync();
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

    public static async void getCNPJDataFromDb()
    {
        string federalDocument = "";
        Empresa empresa;
        try
        {
            Console.Write("Digite o CNPJ (somente números):");
            federalDocument = Console.ReadLine()!; // ! is used to suppress null warning
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        empresa = await db.FindAsync(entityType: Type.GetType("Empresa"), federalDocument) as Empresa;
        Console.WriteLine(empresa);
    }

    public static void CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<EmpresaProfile>();
        }, loggerFactory);

        mapper = config.CreateMapper();
    }

    public static async void getCep()
    {
        string cepString = "";
        try
        {
            Console.Write("Digite o CEP (somente números):");
            cepString = Console.ReadLine()!; // ! é para suprimir o aviso de possível nulo
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            using HttpResponseMessage response = await client.GetAsync($"{uri}{apiEndpoints["CEP"]}{cepString}"); // Aguarda a resposta assíncrona
            if (response.IsSuccessStatusCode)
            {
                // Faz a leitura do conteúdo da respota(JSON)
                string responseContent = response.Content.ReadAsStringAsync().Result;
                // Desserializa o JSON para o objeto CepDTO
                CepDTO cepData = JsonSerializer.Deserialize<CepDTO>(responseContent)!; // ! é para suprimir o aviso de possível nulo
                PropertyPrinter.PrintProperties(cepData);
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
}