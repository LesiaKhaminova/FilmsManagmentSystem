using DAL.BaseEntities;
using DAL.Utils;
using Microsoft.EntityFrameworkCore;

namespace DAL.DBContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().HasData(
               new Film
               {
                   Id = 1,
                   Title = "Inception",
                   Genre = FilmGenre.ScienceFiction,
                   Director = "Christopher Nolan",
                   ReleaseYear = 2010,
                   Rating = 9,
                   Description = "A mind-bending thriller where dreams and reality blend.",
                   Image = "https://th.bing.com/th/id/OIP.Scqbt4kUs8tnBai7bT4ZTgHaEL?rs=1&pid=ImgDetMain"
               },
               new Film
               {
                   Id = 2,
                   Title = "The Dark Knight",
                   Genre = FilmGenre.Comedy,
                   Director = "Christopher Nolan",
                   ReleaseYear = 2008,
                   Rating = 9,
                   Description = "Batman faces off against the Joker in a battle for Gotham.",
                   Image = "https://th.bing.com/th/id/R.9dea9ababa3ad7f21359ffcb057faefd?rik=4Lk1jTgavlYEog&riu=http%3a%2f%2fwww.studioremarkable.com%2fwp-content%2fuploads%2f2012%2f08%2fDark-Knight-Trilogy.jpg&ehk=D%2bFvpPCEqUoo4GUlHzYK8Fz8RU8nkjeBz5q46V7PRwY%3d&risl=&pid=ImgRaw&r=0"
               },
               new Film
               {
                   Id = 3,
                   Title = "The Matrix",
                   Genre = FilmGenre.Romance,
                   Director = "The Wachowskis",
                   ReleaseYear = 1999,
                   Rating = 8,
                   Description = "A computer hacker learns about the true nature of reality.",
                   Image = "https://th.bing.com/th/id/OIP.QdsZ5NsxPLcQPUrW4GkKQgHaEK?rs=1&pid=ImgDetMain"
               },
               new Film
               {
                   Id = 4,
                   Title = "The Godfather",
                   Genre = FilmGenre.Adventure,
                   Director = "Francis Ford Coppola",
                   ReleaseYear = 1972,
                   Rating = 10,
                   Description = "The aging patriarch of an organized crime dynasty transfers " +
                   "control of his clandestine empire to his reluctant son.",
                   Image = "https://images5.alphacoders.com/131/1315822.jpg"
               },
               new Film
               {
                   Id = 5,
                   Title = "Schindler's List",
                   Genre = FilmGenre.Drama,
                   Director = "Steven Spielberg",
                   ReleaseYear = 1993,
                   Rating = 10,
                   Description = "In Nazi-occupied Poland, Oskar Schindler gradually becomes " +
                   "concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                   Image = "https://images5.alphacoders.com/341/thumb-1920-341183.jpg"
               },
               new Film
               {
                   Id = 6,
                   Title = "Pulp Fiction",
                   Genre = FilmGenre.Romance,
                   Director = "Quentin Tarantino",
                   ReleaseYear = 1994,
                   Rating = 9,
                   Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a" +
                   " pair of diner bandits intertwine in four tales of violence and redemption.",
                   Image = "https://th.bing.com/th/id/OIP.UBzLyakmqVJXBPHmQasvGAHaEK?rs=1&pid=ImgDetMain"
               },
               new Film
               {
                   Id = 7,
                   Title = "Forrest Gump",
                   Genre = FilmGenre.Thriller,
                   Director = "Robert Zemeckis",
                   ReleaseYear = 1994,
                   Rating = 9,
                   Description = "The presidencies of Kennedy and Johnson, the Vietnam War, " +
                   "the Watergate scandal and other historical events unfold from the perspective of" +
                   " an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                   Image = "https://ntvb.tmsimg.com/assets/p15829_v_h8_aw.jpg?w=1280&h=720"
               },
               new Film
               {
                   Id = 8,
                   Title = "The Shawshank Redemption",
                   Genre = FilmGenre.Drama,
                   Director = "Frank Darabont",
                   ReleaseYear = 1994,
                   Rating = 10,
                   Description = "Two imprisoned men bond over a number of years, finding solace and" +
                   " eventual redemption through acts of common decency.",
                   Image = "https://th.bing.com/th/id/R.304c3c3655c48e3985e5da998590713b?rik=DbOR8rxZiByAug&pid=ImgRaw&r=0"
               },
               new Film
               {
                   Id = 9,
                   Title = "Gladiator",
                   Genre = FilmGenre.Adventure,
                   Director = "Ridley Scott",
                   ReleaseYear = 2000,
                   Rating = 8,
                   Description = "A former Roman General sets out to exact vengeance against the" +
                   " corrupt emperor who murdered his family and sent him into slavery.",
                   Image = "https://static1.moviewebimages.com/wordpress/wp-content/uploads/2024/07/paul-mescal-in-gladiator-2.jpg"
               },
               new Film
               {
                   Id = 10,
                   Title = "Titanic",
                   Genre = FilmGenre.Thriller,
                   Director = "James Cameron",
                   ReleaseYear = 1997,
                   Rating = 8,
                   Description = "A seventeen-year-old aristocrat falls in love with a kind" +
                   " but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                   Image = "https://www.themoviedb.org/t/p/original/vIAm7UDNjGztvUYtDuS0in1VAXg.jpg"
               },
               new Film
               {
                   Id = 11,
                   Title = "Avatar",
                   Genre = FilmGenre.Fantasy,
                   Director = "James Cameron",
                   ReleaseYear = 2009,
                   Rating = 8,
                   Description = "A paraplegic marine dispatched to the moon Pandora on a " +
                   "unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                   Image = "https://th.bing.com/th/id/R.fa78b5d06e0ed8f9723d8b7d9b26afc6?rik=JOCHURLPc%2f2YhA&pid=ImgRaw&r=0"
               },
               new Film
               {
                   Id = 12,
                   Title = "The Lion King",
                   Genre = FilmGenre.Horror,
                   Director = "Roger Allers, Rob Minkoff",
                   ReleaseYear = 1994,
                   Rating = 9,
                   Description = "Lion prince Simba and his father are targeted by his " +
                   "bitter uncle, who wants to ascend the throne himself.",
                   Image = "https://townsquare.media/site/442/files/2016/09/lion-king.jpg?w=1200&h=0&zc=1&s=0&a=t&q=89"
               },
               new Film
               {
                   Id = 13,
                   Title = "Jurassic Park",
                   Genre = FilmGenre.Fantasy,
                   Director = "Steven Spielberg",
                   ReleaseYear = 1993,
                   Rating = 8,
                   Description = "During a preview tour, a theme park suffers a major power breakdown " +
                   "that allows its cloned dinosaur exhibits to run amok.",
                   Image = "https://orlandoinformer.com/wp-content/uploads/2020/06/Jurassic-park-gate-IOA.jpg"
               },
               new Film
               {
                   Id = 14,
                   Title = "Fight Club",
                   Genre = FilmGenre.ScienceFiction,
                   Director = "David Fincher",
                   ReleaseYear = 1999,
                   Rating = 8,
                   Description = "An insomniac office worker, looking for a way to change his life, " +
                   "crosses paths with a devil-may-care soap maker, forming an underground fight club.",
                   Image = "https://images.indianexpress.com/2023/11/Poster-of-Fight-Club.jpg"
               },
               new Film
               {
                   Id = 15,
                   Title = "Star Wars: Episode IV - A New Hope",
                   Genre = FilmGenre.Thriller,
                   Director = "George Lucas",
                   ReleaseYear = 1977,
                   Rating = 9,
                   Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, " +
                   "a Wookiee, and two droids to rescue Princess Leia from the clutches of the evil Empire.",
                   Image = "https://cdn.mos.cms.futurecdn.net/UB8sg7fS5tggpXXYrYyGHG-1200-80.jpg"
               }
           );
        }
    }
}
