using BLL.DTO;

namespace FilmsApiTests.Utils
{
    public class ResponseComparer : IEqualityComparer<Response>
    {
        public bool Equals(Response? x, Response? y)
        {
            if (x == null && y == null) return true;

            if (x == null || y == null) return false;

            if (x.Result is List<FilmResponse> filmsX && y.Result is List<FilmResponse> filmsY)
            {
                if (filmsX.Count != filmsY.Count) return false;

                var comparer = new FilmResponseComparer();
                if (!filmsX.SequenceEqual(filmsY, comparer)) 
                {
                    return false;
                }

                return true;
            }

            if (x.Result is FilmResponse filmX && y.Result is FilmResponse filmY)
            {
                var comparer = new FilmResponseComparer();
                if (!comparer.Equals(filmX, filmY)) 
                {
                    return false;
                }

                return true;
            }

            for(int i = 0; i< x.ErrorMessages.Count; i++)
            {
                if(x.ErrorMessages[i] != y.ErrorMessages[i])
                {
                    return false;
                }
            }

            return x.IsSuccess == y.IsSuccess &&
                  CompareObjects(x.Result, y.Result);
        }

        public int GetHashCode(Response obj)
        {
            int hashCode = obj.IsSuccess.GetHashCode(); 

            hashCode = hashCode * 31 + (obj.ErrorMessages != null ? obj.ErrorMessages.GetHashCode() : 0);

            hashCode = hashCode * 31 + (obj.Result != null ? obj.Result.GetHashCode() : 0);

            return hashCode;
        }

        private bool CompareObjects(object? obj1, object? obj2)
        {
            if (obj1 is null && obj2 is null) return true;

            if (obj1 is null || obj2 is null) return false;

            return obj1.Equals(obj2);
        }
    }
}
