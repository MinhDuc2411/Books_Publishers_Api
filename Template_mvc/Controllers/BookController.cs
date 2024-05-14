using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Template_mvc.Models;

namespace Template_mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            List<BookDTO> response = new List<BookDTO>(); // tạo đối tượng với model Book
            try
            {
                var client = httpClientFactory.CreateClient(); //khởi tạo Client 
                var httpResponseMess = await client.GetAsync("https://localhost:7245/api/Books/get-allbooks"); // lấy dữ liệu Get books from API với url từ API
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
            return View();
        }
    }
}
