//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Xunit;

//public class FilmsRepositoryTests
//{
//    private Mock<ApplicationDbContext> GetDbContextMock()
//    {
//        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
//            .UseInMemoryDatabase(databaseName: "TestDb")
//            .Options;

//        var mockContext = new Mock<ApplicationDbContext>(options);
//        return mockContext;
//    }

//    [Fact]
//    public async Task AddFilm_Should_Add_Film_To_Database()
//    {
//        // Arrange
//        var dbContextMock = GetDbContextMock();
//        var repository = new FilmsRepository(dbContextMock.Object);
//        var newFilm = new Film { Id = 1, Title = "Test Film" };

//        dbContextMock.Setup(db => db.Films.Add(It.IsAny<Film>())).Verifiable();
//        dbContextMock.Setup(db => db.SaveChangesAsync(default)).ReturnsAsync(1);

//        // Act
//        await repository.AddFilm(newFilm);

//        // Assert
//        dbContextMock.Verify(db => db.Films.Add(It.IsAny<Film>()), Times.Once);
//        dbContextMock.Verify(db => db.SaveChangesAsync(default), Times.Once);
//    }

//    [Fact]
//    public async Task DeleteFilm_Should_Remove_Film_From_Database()
//    {
//        // Arrange
//        var dbContextMock = GetDbContextMock();
//        var repository = new FilmsRepository(dbContextMock.Object);
//        int filmId = 1;

//        dbContextMock.Setup(db => db.Films.RemoveRange(It.IsAny<IEnumerable<Film>>())).Verifiable();
//        dbContextMock.Setup(db => db.SaveChangesAsync(default)).ReturnsAsync(1);

//        // Act
//        var result = await repository.DeleteFilm(filmId);

//        // Assert
//        Assert.True(result);
//        dbContextMock.Verify(db => db.Films.RemoveRange(It.IsAny<IEnumerable<Film>>()), Times.Once);
//        dbContextMock.Verify(db => db.SaveChangesAsync(default), Times.Once);
//    }

//    [Fact]
//    public async Task GetAllFilms_Should_Return_List_Of_Films()
//    {
//        // Arrange
//        var films = new List<Film>
//        {
//            new Film { Id = 1, Title = "Film1" },
//            new Film { Id = 2, Title = "Film2" }
//        }.AsQueryable();

//        var dbContextMock = GetDbContextMock();
//        var dbSetMock = new Mock<DbSet<Film>>();

//        dbSetMock.As<IQueryable<Film>>().Setup(m => m.Provider).Returns(films.Provider);
//        dbSetMock.As<IQueryable<Film>>().Setup(m => m.Expression).Returns(films.Expression);
//        dbSetMock.As<IQueryable<Film>>().Setup(m => m.ElementType).Returns(films.ElementType);
//        dbSetMock.As<IQueryable<Film>>().Setup(m => m.GetEnumerator()).Returns(films.GetEnumerator());

//        dbContextMock.Setup(db => db.Films).Returns(dbSetMock.Object);

//        var repository = new FilmsRepository(dbContextMock.Object);

//        // Act
//        var result = await repository.GetAllFilms();

//        // Assert
//        Assert.Equal(2, result.Count);
//    }
//}