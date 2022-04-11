using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Webservice.REST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ExampleService
    {
        private static List<String> books = new List<string>(new String[] { "The Fellowship of the Ring", "The Two Towers", "The Return of the King", "Design Patterns: Elements of Reusable Object-Oriented Software" });


        [WebGet(UriTemplate = "/Books")]
        public String GetAllBooks()
        {
            String Books = "";
            foreach (var book in books)
            {
                Books += Books + book + ", ";
            }
            return Books;
        }

        [WebGet(UriTemplate = "/Books/{bookID}")]
        public String GetBookID(String BookID)
        {
            int bookID;
            Int32.TryParse(BookID, out bookID);
            return books[bookID];
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddBook(String BookTitle) 
        {
            books.Add(BookTitle);
        }

        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Books/{BookID}", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteBook(String BookID)
        {
            int bookID;
            Int32.TryParse(BookID, out bookID);
            books.RemoveAt(bookID);
        }
    }
}
