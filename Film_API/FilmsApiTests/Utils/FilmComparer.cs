using DAL.BaseEntities;

namespace FilmsApiTests.Utils
{
    public class FilmComparer : IEqualityComparer<Film>
    {
        public bool Equals(Film? x, Film? y)
        {
            if (x is null || y is null) return false;
            return x.Id == y.Id &&
                   x.Title == y.Title &&
                   x.Genre == y.Genre &&
                   x.Director == y.Director &&
                   x.ReleaseYear == y.ReleaseYear &&
                   x.Rating == y.Rating &&
                   x.Description == y.Description &&
                   x.Image == y.Image;
        }

        public int GetHashCode(Film obj)
        {
            return HashCode.Combine(obj.Id, obj.Title, obj.Genre, obj.Director, obj.ReleaseYear, obj.Rating, obj.Description, obj.Image);
        }
    }
}
