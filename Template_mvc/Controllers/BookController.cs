using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Template_mvc.DTOs;
using Template_mvc.DTOs;

namespace Template_mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public BookController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index([FromQuery] string filterOn = null, string filterQuery = null,string sortBy=null,bool isAscending=true)
        {
            List<BookDTO> response = new List<BookDTO>(); // tạo đối tượng với model Book

            try
            {
                var client = httpClientFactory.CreateClient(); //khởi tạo Client 
                var httpResponseMess = await client.GetAsync("https://localhost:7129/api/Book" +
                   "filterOn ="+filterOn+ " &filterQuery ="+filterQuery+"&sortBy="+sortBy+ "&isAscending=" +isAscending+""); // lấy dữ liệu Get books from API với url từ API
                httpResponseMess.EnsureSuccessStatusCode(); // kiểm tra mã trạng thái trả về 200
                response.AddRange(await
               httpResponseMess.Content.ReadFromJsonAsync<IEnumerable<BookDTO>>());
                // đổi kiểu dữ liệu từ Json sang mảng đối tượng BookDTO
            }
            catch (Exception ex)
            {
                //log the exception
            }
            return View(response); //truyền dữ liệu sang View thông qua biến response 

        }
    }
    //[HttpPost]
    //public async Task<IActionResult> addBook(addBookDTO addBookDTO)
    //{
    //    try
    //    {
    //        using(var client = httpClientFactory.CreateClient();
    //        var httpRequestMess = new HttpRequestMessage()
    //        {
    //            Method = HttpMethod.Post,
    //            RequestUri = new Uri("https://localhost:7245/api/Books/get-all-books"),
    //            Content = new StringContent(JsonSerializer.Serialize(addBookDTO),.Application.Json)
    //        };
    //        //Console.WriteLine(JsonSerializer.Serialize(addBookDTO));
    //        var httpReponseMess = await client.SendAsync(httpRequestMess);
    //        httpReponseMess.EnsureSuccessStatusCode();
    //        var response = await httpReponseMess.Content.ReadFromJsonAsync<addBookDTO>();
    //        if(response != null)
    //        {
    //            return  ("Index", "Books");
    //        }

    //    }
    //    catch(Exception ex)
    //    {
    //        ViewBag.Error = ex.Message;
    //    }
    //    return View(addBookDTO);
       
    //}
}
