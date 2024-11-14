using RevisionClient.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RevisionClient.Services
{
    public class WSService
    {
        HttpClient client = new HttpClient();

        public WSService(string url)
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<EnrollmentDTO>> GetAllProduitsAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<EnrollmentDTO>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<StudentDTO>> GetAllStudentAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<StudentDTO>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
        //public async Task<List<TypeProduitDTO>> GetAllTypeProduitAsync(string nomControleur)
        //{
        //    try
        //    {
        //        return await client.GetFromJsonAsync<List<TypeProduitDTO>>(nomControleur);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<List<MarqueDTO>> GetAllMarqueAsync(string nomControleur)
        //{
        //    try
        //    {
        //        return await client.GetFromJsonAsync<List<MarqueDTO>>(nomControleur);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public async Task<ProduitDetailDto> GetByStringAsync(string nom)
        //{
        //    try
        //    {
        //        return await client.GetFromJsonAsync<ProduitDetailDto>($"produits/ByNom/{nom}");
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}



        //public async Task<bool> PostProduitAsync(Produit p)
        //{
        //    try
        //    {
        //        var response = await client.PostAsJsonAsync("produits/", p);
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}



        //public async Task<bool> PutProduitAsync(Produit p)
        //{
        //    try
        //    {
        //        var response = await client.PutAsJsonAsync($"produits/{p.IdProduit}", p);
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> DeleteProduitAsync(Produit p)
        //{
        //    try
        //    {
        //        var response = await client.DeleteAsync($"produits/{p.IdProduit}");
        //        return response.IsSuccessStatusCode;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<ProduitDetailDto> GetProduitByIdAsync(int idProduit)
        //{
        //    try
        //    {
        //        return await client.GetFromJsonAsync<ProduitDetailDto>(String.Concat(client.BaseAddress, $"produits/ById/{idProduit}"));
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}

