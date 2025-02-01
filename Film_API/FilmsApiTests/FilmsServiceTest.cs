using AutoMapper;
using BLL.DTO;
using BLL.Utils;
using BLL.Services;
using DAL.BaseEntities;
using DAL.DBContext;
using DAL.Utils;
using DAL.Repositories;
using FilmsApiTests.Utils;
using Microsoft.EntityFrameworkCore;

namespace FilmsApiTests
{
    public class FilmsServiceTest
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

        private FilmsService GetFilmsService()
        {
            var dbContext = GetInMemoryDbContext();
            var repository = new FilmsRepository(dbContext);
            var config = new MapperConfiguration(cfg => cfg.AddProfile<FilmsAutoMapper>());
            var mapper = new Mapper(config);
            return new FilmsService(repository, mapper);
        }

        [Fact]
        public async Task GetFilmById_Should_Return_Correct_Film()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                Result =  new FilmResponse 
                {
                    Id = 2,
                    Title = "The Godfather",
                    Genre = "Drama",
                    Director = "Francis Ford Coppola",
                    ReleaseYear = 1972,
                    Rating = 2,
                    Description = "A mafia epic",
                    Image = "godfather.jpg"
                },
                IsSuccess = true
            };
                
            // Act
            var result = await service.GetFilmById(2);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer()); 
        }

        [Fact]
        public async Task GetFilmById_Incorrect_Id_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                ErrorMessages = new List<string>() { "The given film does not exists" },
                IsSuccess = false
            };

            // Act
            var result = await service.GetFilmById(200); 

            // Assert
            Assert.Equal(expected, result, new ResponseComparer()); 
        }

        [Fact]
        public async Task Delete_Incorrect_Id_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                ErrorMessages = new List<string>() { "The given film does not exists" },
                IsSuccess = false
            };

            // Act
            var result = await service.DeleteFilm(200);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Delete_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = true
            };

            // Act
            var result = await service.DeleteFilm(2);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_All_Films_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = new List<FilmResponse>() {
                    new FilmResponse { Id = 1, Title = "Inception", Genre = "Horror", Director = "Christopher Nolan",
                        ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                    new FilmResponse { Id = 2, Title = "The Godfather", Genre = "Drama", Director = "Francis Ford Coppola",
                        ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                    new FilmResponse { Id = 3, Title = "The Dark Knight", Genre = "Adventure", Director = "Christopher Nolan",
                        ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                    new FilmResponse { Id = 4, Title = "Pulp Fiction", Genre = "Comedy", Director = "Quentin Tarantino",
                        ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                    new FilmResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis",
                        ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                    new FilmResponse { Id = 6, Title = "The Matrix", Genre = "Adventure", Director = "Lana & Lilly Wachowski",
                        ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                    new FilmResponse { Id = 7, Title = "Interstellar", Genre = "ScienceFiction", Director = "Christopher Nolan",
                        ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                    new FilmResponse { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher",
                        ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                    new FilmResponse { Id = 9, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont",
                        ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                    new FilmResponse { Id = 10, Title = "Gladiator", Genre = "Horror", Director = "Ridley Scott",
                        ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" } 
                }
            };

            // Act
            var result = await service.GetAllFilms();

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Genre_Correct_Genre_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = new List<FilmResponse>() {
                    new FilmResponse { Id = 2, Title = "The Godfather", Genre = "Drama", Director = "Francis Ford Coppola",
                        ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                    new FilmResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis",
                        ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                    new FilmResponse { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher",
                        ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                    new FilmResponse { Id = 9, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont",
                        ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                }
            };

            // Act
            var result = await service.GetFilmsSortedByGenre("Drama");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Genre_InCorrect_Genre_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "The given film genre does not exists" }
            };

            // Act
            var result = await service.GetFilmsSortedByGenre("lbhvhb");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Genre_Null_Genre_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Argument null exception" }
            };

            // Act
            var result = await service.GetFilmsSortedByGenre(null);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Rating_Correct_Rating_ASC_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = new List<FilmResponse>() {
                    new FilmResponse { Id = 1, Title = "Inception", Genre = "Horror", Director = "Christopher Nolan",
                        ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                    new FilmResponse { Id = 2, Title = "The Godfather", Genre = "Drama", Director = "Francis Ford Coppola",
                        ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                    new FilmResponse { Id = 3, Title = "The Dark Knight", Genre = "Adventure", Director = "Christopher Nolan",
                        ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                    new FilmResponse { Id = 4, Title = "Pulp Fiction", Genre = "Comedy", Director = "Quentin Tarantino",
                        ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                    new FilmResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis",
                        ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                    new FilmResponse { Id = 6, Title = "The Matrix", Genre = "Adventure", Director = "Lana & Lilly Wachowski",
                        ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                    new FilmResponse { Id = 7, Title = "Interstellar", Genre = "ScienceFiction", Director = "Christopher Nolan",
                        ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                    new FilmResponse { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher",
                        ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                    new FilmResponse { Id = 9, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont",
                        ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                    new FilmResponse { Id = 10, Title = "Gladiator", Genre = "Horror", Director = "Ridley Scott",
                        ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" }
                }
            };

            // Act
            var result = await service.GetFilmsSortedByRating("asc");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Rating_Correct_Rating_DESC_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = new List<FilmResponse>() {                                                                                                                                                                          
                    new FilmResponse { Id = 10, Title = "Gladiator", Genre = "Horror", Director = "Ridley Scott",
                        ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" },
                    new FilmResponse { Id = 9, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont",
                        ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                    new FilmResponse { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher",
                        ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                    new FilmResponse { Id = 7, Title = "Interstellar", Genre = "ScienceFiction", Director = "Christopher Nolan",
                        ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                    new FilmResponse { Id = 6, Title = "The Matrix", Genre = "Adventure", Director = "Lana & Lilly Wachowski",
                        ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                    new FilmResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis",
                        ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                    new FilmResponse { Id = 4, Title = "Pulp Fiction", Genre = "Comedy", Director = "Quentin Tarantino",
                        ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                    new FilmResponse { Id = 3, Title = "The Dark Knight", Genre = "Adventure", Director = "Christopher Nolan",
                        ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                    new FilmResponse { Id = 2, Title = "The Godfather", Genre = "Drama", Director = "Francis Ford Coppola",
                        ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                    new FilmResponse { Id = 1, Title = "Inception", Genre = "Horror", Director = "Christopher Nolan",
                        ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                }
            };

            // Act
            var result = await service.GetFilmsSortedByRating("desc");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Rating_InCorrect_Rating_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Unexpected sort order name" }
            };

            // Act
            var result = await service.GetFilmsSortedByRating("bdcjbcnj");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Get_Films_Sorted_By_Rating_Null_Rating_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Argument null exception" }
            };

            // Act
            var result = await service.GetFilmsSortedByRating(null);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Update_Film_Correct_Request_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response()
            {
                IsSuccess = true,
                Result = new FilmResponse()
                {
                    Id = 1,
                    Title = "Inception",
                    Genre = "Horror",
                    Director = "Christopher Nolan",
                    ReleaseYear = 2000,
                    Rating = 3,
                    Description = "A mind-bending thriller",
                    Image = "inception.jpg"
                }
            };

            // Act
            var filmToUpdate = new FilmUpdateRequest()
            {
                Id = 1,
                Title = "Inception",
                Genre = "Horror",
                Director = "Christopher Nolan",
                ReleaseYear = 2000,
                Rating = 3,
                Description = "A mind-bending thriller",
                Image = "inception.jpg"
            };
            var result = await service.UpdateFilm(filmToUpdate);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Update_Film_Null_Request_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Argument null exception" }
            };

            // Act    
            var result = await service.UpdateFilm(null);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Update_Film_Does_Not_Exists_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "The given film does not exists" }
            };

            // Act    
            var filmToUpdate = new FilmUpdateRequest()
            {
                Id = 202,
                Title = "Inception",
                Genre = "Horror",
                Director = "Christopher Nolan",
                ReleaseYear = 2000,
                Rating = 3,
                Description = "A mind-bending thriller",
                Image = "inception.jpg"
            };
            var result = await service.UpdateFilm(filmToUpdate);

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Search_Film_By_Correct_Title_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                Result = new List<FilmResponse>() 
                {
                    new FilmResponse()
                    {
                        Id = 2,
                        Title = "The Godfather",
                        Genre = "Drama",
                        Director = "Francis Ford Coppola",
                        ReleaseYear = 1972,
                        Rating = 2,
                        Description = "A mafia epic",
                        Image = "godfather.jpg"
                    },
                },
                IsSuccess = true
            };

            // Act    
            var result = await service.SearchFilms("godfather");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Search_Film_By_Correct_Director_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                Result = new List<FilmResponse>()
                {
                    new FilmResponse()
                    {
                        Id = 1,
                        Title = "Inception",
                        Genre = "Horror",
                        Director = "Christopher Nolan",
                        ReleaseYear = 2010,
                        Rating = 1,
                        Description = "A mind-bending thriller",
                        Image = "inception.jpg"
                    },
                    new FilmResponse()
                    {
                        Id = 3,
                        Title = "The Dark Knight",
                        Genre = "Adventure",
                        Director = "Christopher Nolan",
                        ReleaseYear = 2008,
                        Rating = 3,
                        Description = "Batman vs Joker",
                        Image = "dark_knight.jpg" },
                    new FilmResponse()
                    {
                        Id = 7,
                        Title = "Interstellar",
                        Genre = "ScienceFiction",
                        Director = "Christopher Nolan",
                        ReleaseYear = 2014,
                        Rating = 7,
                        Description = "A journey through space and time",
                        Image = "interstellar.jpg"
                    },
                },
                IsSuccess = true
            };

            // Act    
            var result = await service.SearchFilms("Christopher", "director");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Search_Film_By_Empty_Search_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = true,
                Result = new List<FilmResponse>() {
                    new FilmResponse { Id = 1, Title = "Inception", Genre = "Horror", Director = "Christopher Nolan",
                        ReleaseYear = 2010, Rating = 1, Description = "A mind-bending thriller", Image = "inception.jpg" },
                    new FilmResponse { Id = 2, Title = "The Godfather", Genre = "Drama", Director = "Francis Ford Coppola",
                        ReleaseYear = 1972, Rating = 2, Description = "A mafia epic", Image = "godfather.jpg" },
                    new FilmResponse { Id = 3, Title = "The Dark Knight", Genre = "Adventure", Director = "Christopher Nolan",
                        ReleaseYear = 2008, Rating = 3, Description = "Batman vs Joker", Image = "dark_knight.jpg" },
                    new FilmResponse { Id = 4, Title = "Pulp Fiction", Genre = "Comedy", Director = "Quentin Tarantino",
                        ReleaseYear = 1994, Rating = 4, Description = "Non-linear crime story", Image = "pulp_fiction.jpg" },
                    new FilmResponse { Id = 5, Title = "Forrest Gump", Genre = "Drama", Director = "Robert Zemeckis",
                        ReleaseYear = 1994, Rating = 5, Description = "Life is like a box of chocolates", Image = "forrest_gump.jpg" },
                    new FilmResponse { Id = 6, Title = "The Matrix", Genre = "Adventure", Director = "Lana & Lilly Wachowski",
                        ReleaseYear = 1999, Rating = 6, Description = "What is the Matrix?", Image = "matrix.jpg" },
                    new FilmResponse { Id = 7, Title = "Interstellar", Genre = "ScienceFiction", Director = "Christopher Nolan",
                        ReleaseYear = 2014, Rating = 7, Description = "A journey through space and time", Image = "interstellar.jpg" },
                    new FilmResponse { Id = 8, Title = "Fight Club", Genre = "Drama", Director = "David Fincher",
                        ReleaseYear = 1999, Rating = 8, Description = "The first rule of Fight Club...", Image = "fight_club.jpg" },
                    new FilmResponse { Id = 9, Title = "The Shawshank Redemption", Genre = "Drama", Director = "Frank Darabont",
                        ReleaseYear = 1994, Rating = 9, Description = "Hope can set you free", Image = "shawshank.jpg" },
                    new FilmResponse { Id = 10, Title = "Gladiator", Genre = "Horror", Director = "Ridley Scott",
                        ReleaseYear = 2000, Rating = 10, Description = "Are you not entertained?", Image = "gladiator.jpg" }
                }
            };

            // Act    
            var result = await service.SearchFilms("");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Search_Film_Invalid_SearchCriteria_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Invalid search criteria provided" },
            };

            // Act    
            var result = await service.SearchFilms("","hvbgvgkevfhbwefghgi");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

        [Fact]
        public async Task Search_Film_Invalid_Search_Should_Return_Correct_Response()
        {
            // Arrange
            var service = GetFilmsService();
            var expected = new Response
            {
                IsSuccess = false,
                ErrorMessages = new List<string>() { "Such films do not exist" },
            };

            // Act    
            var result = await service.SearchFilms("hvbgvgkevfhbwefghgi");

            // Assert
            Assert.Equal(expected, result, new ResponseComparer());
        }

    }
}
