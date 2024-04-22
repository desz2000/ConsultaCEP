using RestSharp;
using Newtonsoft.Json;

public class Services
{
    public void ConsultaEndereco()
    {
        Console.Write("Digite o seu CEP (apenas numeros): ");
        Endereco adress = new Endereco();
        adress.Cep = Console.ReadLine();

        var client = new RestClient("https://viacep.com.br/ws/");
        var request = new RestRequest($"{adress.Cep}/json/", Method.Get);

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            adress = JsonConvert.DeserializeObject<Endereco>(response.Content);
            Console.WriteLine($"Aqui esta o seu endereço: {adress.Logradouro}, {adress.Bairro}, {adress.Localidade} - {adress.Uf}");
            //Console.WriteLine(response.Content);
        }
        else
        {
            Console.WriteLine($"Erro: {response.ErrorMessage}");
        }
    }
}