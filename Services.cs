using RestSharp;
using Newtonsoft.Json;

public class Services
{
    public string ConsultaEndereco(Endereco adress)
    {
        var client = new RestClient("https://viacep.com.br/ws/");
        var request = new RestRequest($"{adress.Cep}/json/", Method.Get);

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            adress = JsonConvert.DeserializeObject<Endereco>(response.Content);
            return $"Aqui esta o seu endereço: {adress.Logradouro}, {adress.Bairro}, {adress.Localidade} - {adress.Uf}";
        }
        else
        {
            return $"Erro: {response.ErrorMessage}";
        }
    }
}