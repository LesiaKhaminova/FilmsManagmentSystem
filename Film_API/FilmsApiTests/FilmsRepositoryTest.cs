using DAL.BaseEntities;
using DAL.DBContext;
using DAL.Utils;
using DAL.Repositories;
using FilmsApiTests.Utils;
using Microsoft.EntityFrameworkCore;

namespace FilmsApiTests
{
    public class FilmsRepositoryTest
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new ApplicationDbContext(options);
            dbContext.Films.AddRange(new List<Film>
            {
                new Film { Id = 1, Title = "Inception", Genre = FilmGenre.Horror, Director = "Christopher Nolan", 
                    ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                new Film { Id = 2, Title = "The Godfather", Genre = FilmGenre.Drama, Director = "Francis Ford Coppola", 
                    ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                new Film { Id = 3, Title = "The Dark Knight", Genre = FilmGenre.Adventure, Director = "Christopher Nolan", 
                    ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                new Film { Id = 4, Title = "Pulp Fiction", Genre = FilmGenre.Comedy, Director = "Quentin Tarantino", 
                    ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                new Film { Id = 5, Title = "Forrest Gump", Genre = FilmGenre.Drama, Director = "Robert Zemeckis", 
                    ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                new Film { Id = 6, Title = "The Matrix", Genre = FilmGenre.Adventure, Director = "Lana & Lilly Wachowski", 
                    ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                new Film { Id = 7, Title = "Interstellar", Genre = FilmGenre.ScienceFiction, Director = "Christopher Nolan", 
                    ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                new Film { Id = 8, Title = "Fight Club", Genre = FilmGenre.Drama, Director = "David Fincher", 
                    ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                new Film { Id = 9, Title = "The Shawshank Redemption", Genre = FilmGenre.Drama, Director = "Frank Darabont", 
                    ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                new Film { Id = 10, Title = "Gladiator", Genre = FilmGenre.Horror, Director = "Ridley Scott", 
                    ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" }
            });

            dbContext.SaveChanges();

            return dbContext;
        }

        private FilmsRepository GetFilmRepository()
        {
            var dbContext = GetInMemoryDbContext();
            var repository = new FilmsRepository(dbContext);

            return repository;
        }

        [Fact]
        public async Task GetAllFilms_Should_Return_All_Films()
        {
            // Arrange
            var repository = GetFilmRepository();
            var expected = new List<Film>(){
                 new Film { Id = 1, Title = "Inception", Genre = FilmGenre.Horror, Director = "Christopher Nolan",
                    ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                new Film { Id = 2, Title = "The Godfather", Genre = FilmGenre.Drama, Director = "Francis Ford Coppola",
                    ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                new Film { Id = 3, Title = "The Dark Knight", Genre = FilmGenre.Adventure, Director = "Christopher Nolan",
                    ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                new Film { Id = 4, Title = "Pulp Fiction", Genre = FilmGenre.Comedy, Director = "Quentin Tarantino",
                    ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                new Film { Id = 5, Title = "Forrest Gump", Genre = FilmGenre.Drama, Director = "Robert Zemeckis",
                    ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                new Film { Id = 6, Title = "The Matrix", Genre = FilmGenre.Adventure, Director = "Lana & Lilly Wachowski",
                    ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                new Film { Id = 7, Title = "Interstellar", Genre = FilmGenre.ScienceFiction, Director = "Christopher Nolan",
                    ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                new Film { Id = 8, Title = "Fight Club", Genre = FilmGenre.Drama, Director = "David Fincher",
                    ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                new Film { Id = 9, Title = "The Shawshank Redemption", Genre = FilmGenre.Drama, Director = "Frank Darabont",
                    ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                new Film { Id = 10, Title = "Gladiator", Genre = FilmGenre.Horror, Director = "Ridley Scott",
                    ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" }
            };

            // Act
            var result = await repository.GetAllFilms();

            // Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task GetFilmById_Should_Return_Correct_Film()
        {
            //Arrange
            var repository = GetFilmRepository();
            var expected = new Film
            {
                Id = 2,
                Title = "The Godfather",
                Genre = FilmGenre.Drama,
                Director = "Francis Ford Coppola",
                ReleaseYear = 1972,
                Rating = 2,
                Description = "A mafia epic",
                Image = "godfather.jpg"
            };

            //Act
            var result = await repository.GetFilmById(2);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task GetFilmById_Incorrect_Id_Should_Return_Null()
        {
            //Arrange
            var repository = GetFilmRepository();
            Film? expected = null;

            //Act
            var result = await repository.GetFilmById(200);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task GetFilmsSortedByGenre_Should_Return_FilmsList_With_Given_Genre()
        {
            //Arrange
            var repository = GetFilmRepository();
            var expected = new List<Film>() 
            {
                 new Film { Id = 3, Title = "The Dark Knight", Genre = FilmGenre.Adventure, Director = "Christopher Nolan",
                    ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                 new Film { Id = 6, Title = "The Matrix", Genre = FilmGenre.Adventure, Director = "Lana & Lilly Wachowski",
                    ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
            };

            //Act
            var result = await repository.GetFilmsSortedByGenre(FilmGenre.Adventure);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task DeleteFilmById_Should_Return_True()
        {
            //Arrange
            var repository = GetFilmRepository();
            bool expected = true;

            //Act
            var result = await repository.DeleteFilm(1);

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task GetFilmsSortedByRating_ASC_Should_Return_FilmsList_With_Correct_Order()
        {
            //Arrange
            var repository = GetFilmRepository();
            var expected = new List<Film>()
            {
                new Film { Id = 1, Title = "Inception", Genre = FilmGenre.Horror, Director = "Christopher Nolan",
                    ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                new Film { Id = 2, Title = "The Godfather", Genre = FilmGenre.Drama, Director = "Francis Ford Coppola",
                    ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                new Film { Id = 3, Title = "The Dark Knight", Genre = FilmGenre.Adventure, Director = "Christopher Nolan",
                    ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                new Film { Id = 4, Title = "Pulp Fiction", Genre = FilmGenre.Comedy, Director = "Quentin Tarantino",
                    ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                new Film { Id = 5, Title = "Forrest Gump", Genre = FilmGenre.Drama, Director = "Robert Zemeckis",
                    ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                new Film { Id = 6, Title = "The Matrix", Genre = FilmGenre.Adventure, Director = "Lana & Lilly Wachowski",
                    ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                new Film { Id = 7, Title = "Interstellar", Genre = FilmGenre.ScienceFiction, Director = "Christopher Nolan",
                    ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                new Film { Id = 8, Title = "Fight Club", Genre = FilmGenre.Drama, Director = "David Fincher",
                    ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                new Film { Id = 9, Title = "The Shawshank Redemption", Genre = FilmGenre.Drama, Director = "Frank Darabont",
                    ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                new Film { Id = 10, Title = "Gladiator", Genre = FilmGenre.Horror, Director = "Ridley Scott",
                    ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" }
            };

            //Act
            var result = await repository.GetFilmsSortedByRating(SortOrderOptions.ASC);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task GetFilmsSortedByRating_DESC_Should_Return_FilmsList_With_Correct_Order()
        {
            //Arrange
            var repository = GetFilmRepository();
            var expected = new List<Film>()
            {
                new Film { Id = 10, Title = "Gladiator", Genre = FilmGenre.Horror, Director = "Ridley Scott",
                    ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" },
                 new Film { Id = 9, Title = "The Shawshank Redemption", Genre = FilmGenre.Drama, Director = "Frank Darabont",
                    ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                new Film { Id = 8, Title = "Fight Club", Genre = FilmGenre.Drama, Director = "David Fincher",
                    ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                new Film { Id = 7, Title = "Interstellar", Genre = FilmGenre.ScienceFiction, Director = "Christopher Nolan",
                    ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                new Film { Id = 6, Title = "The Matrix", Genre = FilmGenre.Adventure, Director = "Lana & Lilly Wachowski",
                    ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                new Film { Id = 5, Title = "Forrest Gump", Genre = FilmGenre.Drama, Director = "Robert Zemeckis",
                    ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                new Film { Id = 4, Title = "Pulp Fiction", Genre = FilmGenre.Comedy, Director = "Quentin Tarantino",
                    ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                new Film { Id = 3, Title = "The Dark Knight", Genre = FilmGenre.Adventure, Director = "Christopher Nolan",
                    ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                new Film { Id = 2, Title = "The Godfather", Genre = FilmGenre.Drama, Director = "Francis Ford Coppola",
                    ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                new Film { Id = 1, Title = "Inception", Genre = FilmGenre.Horror, Director = "Christopher Nolan",
                    ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" }                                                                                         
            };

            //Act
            var result = await repository.GetFilmsSortedByRating(SortOrderOptions.DESC);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task UpdateFilm_Should_Return_Proper_Film_Details_After_Successful_Update()
        {
            //Arrange
            var repository = GetFilmRepository();
            var expected = new Film
            {
                Id = 2,
                Title = "The Godfather",
                Genre = FilmGenre.Romance,
                Director = "Francis Ford Coppola",
                ReleaseYear = 1980,
                Rating = 4,
                Description = "A mafia epic",
                Image = "godfather.jpg"
            };

            //Act
            var filmToUpdate = new Film
            {
                Id = 2,
                Title = "The Godfather",
                Genre = FilmGenre.Romance,
                Director = "Francis Ford Coppola",
                ReleaseYear = 1980,
                Rating = 4,
                Description = "A mafia epic",
                Image = "godfather.jpg"
            };
            var result = await repository.UpdateFilm(filmToUpdate);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }

        [Fact]
        public async Task UpdateFilm_Film_Does_Not_Exists_Should_Return_Null()
        {
            //Arrange
            var repository = GetFilmRepository();
            Film? expected = null;

            //Act
            var filmToUpdate = new Film
            {
                Id = 200,
                Title = "The Godfather",
                Genre = FilmGenre.Romance,
                Director = "Francis Ford Coppola",
                ReleaseYear = 1980,
                Rating = 4,
                Description = "A mafia epic",
                Image = "godfather.jpg"
            };
            var result = await repository.UpdateFilm(filmToUpdate);

            //Assert
            Assert.Equal(expected, result, new FilmComparer());
        }
    }
}
