import React, { useState } from "react";

import DeleteFilmModal from "./DeleteFilmModal";

function FilmItemCard({ film }) {
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [error, setError] = useState(null);

  const handleDelete = () => {
    debugger;
    fetch(`https://localhost:7269/api/Films/${film.id}`, { method: "DELETE" })
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          setShowDeleteModal(false);
          window.location.reload();
        } else {
          setError(
            data.errorMessages?.join(", ") || "Failed to delete the film"
          );
        }
      })
      .catch((err) => setError(err.message));
  };

  return (
    <div
      className="card m-2 shadow p-3 d-flex flex-row align-items-center my-4"
      style={{ width: "100rem", backgroundColor: "#bcb8b1" }}
    >
      <img
        src={film.image}
        alt="Film Poster"
        className="rounded"
        style={{
          width: "350px",
          height: "250px",
          objectFit: "cover",
          marginRight: "15px",
        }}
      />
      <div className="card-body">
        <div className="d-flex justify-content-end">
          <button
            className="btn btn-danger mt-3 btn-s mx-1 shadow"
            onClick={() => setShowDeleteModal(true)}
          >
            <i className="bi bi-trash3 "></i>
          </button>
          <a
            className="btn btn-warning mt-3 btn-s mx-1 shadow"
            href={`/films/update-film/${film.id}`}
          >
            <i className="bi bi-pencil"></i>
          </a>
        </div>

        <h5 className="card-title fs-1">{film.title}</h5>
        <p className="text-muted mb-1 fs-6">Release year: {film.releaseYear}</p>
        <p className="text-muted mb-1 fs-6">Director: {film.director}</p>
        <p className="text-muted mb-1 fs-6">Genre: {film.genre}</p>
        <p className="text-mutedg fs-6">
          Rating: {film.rating} <i className="bi bi-star-fill text-warning"></i>
        </p>
        <a
          className="btn shadow"
          href={`/films/${film.id}`}
          style={{ backgroundColor: "#B0BEF2" }}
        >
          Read more...
        </a>
      </div>

      <DeleteFilmModal
        show={showDeleteModal}
        onClose={() => setShowDeleteModal(false)}
        onDelete={handleDelete}
      />

      {error && <p className="text-danger mt-3">{error}</p>}
    </div>
  );
}

export default FilmItemCard;
