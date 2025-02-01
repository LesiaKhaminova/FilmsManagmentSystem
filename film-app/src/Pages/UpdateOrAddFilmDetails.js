import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";

function UpdateOrAddFilmDetails() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [film, setFilm] = useState({
    title: "",
    description: "",
    director: "",
    releaseYear: 0,
    image: "",
    rating: 0,
    genre: "",
  });

  const [error, setError] = useState(null);
  const [validationErrors, setValidationErrors] = useState({});

  useEffect(() => {
    if (id) {
      fetch(`https://localhost:7269/api/Films/${id}`)
        .then((response) => response.json())
        .then((data) => {
          if (data.isSuccess) {
            setFilm(data.result);
          } else {
            setError("Error loading film data");
          }
        })
        .catch((err) => setError(err.message));
    }
  }, [id]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFilm((prevFilm) => ({
      ...prevFilm,
      [name]: value,
    }));
    setValidationErrors((prevErrors) => ({
      ...prevErrors,
      [name]: "",
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    debugger;
    const method = id ? "PUT" : "POST";
    const url = id
      ? `https://localhost:7269/api/Films/${id}`
      : "https://localhost:7269/api/Films/add-film";

    fetch(url, {
      method,
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(film),
    })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          navigate(id ? `/` : `/films/${data.result.id}`);
        } else if (data.errors) {
          const validationMessages = Object.values(data.errors)
            .flat()
            .join(", ");
          setError(validationMessages);
          setValidationErrors(data.errors);
        } else if (data.errorMessages) {
          setError(data.errorMessages.join(", "));
        } else {
          setError("Unknown error occurred");
        }
      })
      .catch((err) => setError(err.message));
  };

  return (
    <div className="container mt-5">
      <h2>{id ? "Update Film Details" : "Add New Film"}</h2>
      {error && <div className="alert alert-danger">{error}</div>}
      <form onSubmit={handleSubmit}>
        <div className="mb-3">
          <label htmlFor="title" className="form-label">
            Film Title
          </label>
          <input
            type="text"
            className="form-control"
            id="title"
            name="title"
            value={film.title}
            onChange={handleChange}
            required
          />
          {validationErrors.title && (
            <div className="text-danger">{validationErrors.title}</div>
          )}
        </div>
        <div className="mb-3">
          <label htmlFor="description" className="form-label">
            Description
          </label>
          <textarea
            className="form-control"
            id="description"
            name="description"
            rows="3"
            value={film.description}
            onChange={handleChange}
          ></textarea>
        </div>
        <div className="mb-3">
          <label htmlFor="director" className="form-label">
            Director
          </label>
          <input
            type="text"
            className="form-control"
            id="director"
            name="director"
            value={film.director}
            onChange={handleChange}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="releaseYear" className="form-label">
            Year of Release
          </label>
          <input
            type="number"
            className="form-control"
            id="releaseYear"
            name="releaseYear"
            value={film.releaseYear}
            onChange={handleChange}
            required
          />
        </div>
        <div className="mb-3">
          <label htmlFor="image" className="form-label">
            Image URL
          </label>
          <input
            type="text"
            className="form-control"
            id="image"
            name="image"
            value={film.image}
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label htmlFor="genre" className="form-label">
            Genre
          </label>
          <select
            className="form-control"
            id="genre"
            name="genre"
            value={film.genre}
            onChange={handleChange}
          >
            <option value="" disabled>
              Select Genre
            </option>
            <option value="Adventure">Adventure</option>
            <option value="Comedy">Comedy</option>
            <option value="Drama">Drama</option>
            <option value="Horror">Horror</option>
            <option value="Thriller">Thriller</option>
            <option value="ScienceFiction">Science fiction</option>
            <option value="Fantasy">Fantasy</option>
            <option value="Romance">Romance</option>
          </select>
        </div>
        <div className="mb-3">
          <label htmlFor="rating" className="form-label">
            Rating
          </label>
          <select
            id="rating"
            name="rating"
            value={film.rating}
            onChange={handleChange}
            className="form-control"
          >
            <option value="0" disabled>
              Select raiting
            </option>
            {[...Array(10).keys()].map((n) => (
              <option key={n + 1} value={n + 1}>
                {n + 1}
              </option>
            ))}
          </select>
        </div>
        <button
          type="submit"
          className="btn mt-3 mx-2 shadow"
          style={{ backgroundColor: "#B0F2B8" }}
        >
          {id ? "Save Changes" : "Add Film"}
        </button>
        <a
          href="/"
          className="btn mt-3 mx-2 shadow"
          style={{ backgroundColor: "#CAB0F2" }}
        >
          Back to the main page
        </a>{" "}
      </form>
    </div>
  );
}

export default UpdateOrAddFilmDetails;
