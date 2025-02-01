import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import DeleteFilmModal from "../Components/FilmsItems/DeleteFilmModal";
import { useNavigate } from "react-router-dom";
function FilmItemDetails() {
  const { id } = useParams();
  const [film, setFilm] = useState(null);
  const [error, setError] = useState(null);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const navigate = useNavigate();

  useEffect(() => {
    fetch(`https://localhost:7269/api/Films/${id}`)
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          setFilm(data.result);
        } else {
          setError(data.errorMessages.join(", "));
        }
      })
      .catch((err) => setError(err.message));
  }, [id]);

  if (error) return <p>Error: {error}</p>;
  if (!film) return <p>Loading...</p>;
  const handleDelete = () => {
    fetch(`https://localhost:7269/api/Films/${id}`, { method: "DELETE" })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          navigate(`/`);
        } else {
          setError(
            data.errorMessages?.join(", ") || "Failed to delete the film"
          );
        }
      })
      .catch((err) => setError(err.message));
  };

  return (
    <div className="container mt-5">
      <div className="row justify-content-center p-3">
        <div className="col-md-8">
          <div
            className="card shadow-lg"
            style={{ backgroundColor: "#bcb8b1" }}
          >
            <div className="d-flex justify-content-start">
              <a
                href={`/films/update-film/${film.id}`}
                className="btn btn-warning mt-3 mx-2 shadow"
              >
                Edit
                <i class="bi bi-pencil mx-2"></i>
              </a>
              <button
                className="btn btn-danger mt-3 shadow"
                onClick={() => setShowDeleteModal(true)}
              >
                Delete <i class="bi bi-trash3 mx-1"></i>
              </button>
              <DeleteFilmModal
                show={showDeleteModal}
                onClose={() => setShowDeleteModal(false)}
                onDelete={handleDelete}
              />
            </div>
            <img
              src={film.image}
              alt=""
              className="card-img-top img-fluid rounded mx-auto d-block mt-3"
              style={{
                maxHeight: "400px",
                maxWidth: "800px",
                objectFit: "cover",
              }}
            />
            <div className="card-body">
              <h1 className="card-title text-center">{film.title}</h1>
              <p className="card-text">{film.description}</p>

              <p>
                <strong>Release year: </strong> {film.releaseYear}
              </p>
              <p>
                <strong>Director: </strong> {film.director}
              </p>
              <p className="text-mutted">
                <strong>Raiting: </strong> {film.rating + " "}
                <i class="bi bi-star-fill text-warning"></i>
              </p>

              <div className="text-center">
                <a
                  href="/"
                  className="btn mt-3 mx-2 shadow"
                  style={{ backgroundColor: "#B0F2B8" }}
                >
                  Back to the main page
                </a>{" "}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default FilmItemDetails;
