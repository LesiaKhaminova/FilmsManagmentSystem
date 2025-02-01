using BLL.DTO;

namespace FilmsApiTests.Utils
{
    public class FilmResponseComparer : IEqualityComparer<FilmResponse>
    {
        public bool Equals(FilmResponse? x, FilmResponse? y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Id == y.Id &&
                   x.Title == y.Title &&
                   x.Genre == y.Genre &&
                   x.Director == y.Director &&
                   x.ReleaseYear == y.ReleaseYear &&
                   x.Rating == y.Rating &&
                   x.Description == y.Description &&
                   x.Image == y.Image;
        }

        public int GetHashCode(FilmResponse obj)
        {
            return HashCode.Combine(obj.Id, obj.Title, obj.Genre, obj.Director, obj.ReleaseYear, obj.Rating, obj.Description, obj.Image);
        }
    }
}
