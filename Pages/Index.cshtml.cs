using BookStore.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace BookStore.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Book> GetBooks { get; set; }
        public void OnGet()
        {
            GetBooks = GetCustomers();
        }

        public List<Book> GetCustomers()
        {
            List<Book> books = new List<Book>();
            string connectionString = "Server=tcp:sqlserverkn.database.windows.net,1433;Initial Catalog=sqldbkn;Persist Security Info=False;User ID=kashif;Password=Geneva12;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT * FROM Books";
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        books.Add(new Book()
                        {
                            BookId = Convert.ToInt32(rdr["BookId"]),
                            BookName = rdr["BookName"].ToString(),
                            BookQuantity = Convert.ToInt32(rdr["BookQuantity"])
                        });
                    }
                    con.Close();
                }
            }

            return books;
        }
    }
}