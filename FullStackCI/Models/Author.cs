namespace FullStackCI.Models
{
    public class Author
    {
       /// <summary>
       /// Id del autor
       /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del autor
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Nacionalidad del autor
        /// </summary>
        public string Nationality { get; set; } = string.Empty;

        /// <summary>
        /// Anno nacimiento del autor
        /// </summary>
        public int BirthYear { get; set; }

        /// <summary>
        /// Libros del autor
        /// </summary>
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }

}
