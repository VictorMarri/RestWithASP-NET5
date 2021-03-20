using RestWithASPNETFive.Data.Converter.Contract;
using RestWithASPNETFive.Data.VO;
using RestWithASPNETFive.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETFive.Data.Converter.Implementations
{
    /// <summary>
    /// Classe que realizará a converrsão dos dados da entidade base para um VO
    /// </summary>
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        /// <summary>
        /// De Book para BookVO
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Book</returns>
        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        /// <summary>
        /// De lista de Book para lista de BookVO
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Lista de Book</returns>
        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }

        /// <summary>
        /// De BookVO para Book
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Book</returns>
        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;
            }

            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        /// <summary>
        /// De lista de BookVo para Lista de VO
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Lista de BookVO</returns>
        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
            {
                return null;
            }

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
