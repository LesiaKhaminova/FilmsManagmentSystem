import React from "react";
import { useState, useEffect } from "react";
import { FilmsItemsList } from "../Components/FilmsItems";
import debounce from "lodash.debounce";

function Home() {
  const [films, setFilms] = useState([]);
  const [filteredFilms, setFilteredFilms] = useState([]);
  const [error, setError] = useState(null);
  const [searchBy, setSearchBy] = useState("title");
  const [searchQuery, setSearchQuery] = useState("");
  const [sortOrder, setSortOrder] = useState("desc");
  const [genre, setGenre] = useState("");
  const [genres] = useState([
    "Adventure",
    "Comedy",
    "Drama",
    "Horror",
    "Thriller",
    "Fantasy",
    "Romance",
    "ScienceFiction",
  ]);

  const fetchFilms = () => {
    fetch("https://localhost:7269/api/Films/get-films")
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          setFilms(data.result);
          setFilteredFilms(data.result);
        } else {
          setError(data.errorMessages.join(", "));
        }
      })
      .catch((err) => setError(err.message));
  };

  useEffect(() => {
    fetchFilms();
  }, []);

  useEffect(() => {
    const fetchFilteredFilms = async () => {
      if (searchQuery) {
        const response = await fetch(
          `https://localhost:7269/api/films/search-film?search=${searchQuery}&searchBy=${searchBy}`
        );
        const data = await response.json();

        if (response.ok) {
          setFilteredFilms(data.result);
        } else {
          console.error("Ошибка фильтрации фильмов:", data.errorMessages);
        }
      } else {
        setFilteredFilms(films);
      }
    };

    const debouncedSearch = debounce(fetchFilteredFilms, 500);
    debouncedSearch();

    return () => {
      debouncedSearch.cancel();
    };
  }, [searchQuery, searchBy, films]);

  const fetchSortedFilms = () => {
    const newSortOrder = sortOrder === "asc" ? "desc" : "asc";
    setSortOrder(newSortOrder);

    fetch(
      ` https://localhost:7269/api/Films/get-films-sorted-by-rating?sortOrder=${newSortOrder}`
    )
      .then((response) => response.json())
      .then((data) => {
        if (data.isSuccess) {
          setFilms(data.result);
          setFilteredFilms(data.result);
        } else {
          setError(data.errorMessages.join(", "));
        }
      })
      .catch((err) => setError(err.message));
  };

  const fetchFilmsByGenre = () => {
    if (genre === "All") {
      fetchFilms();
    } else {
      fetch(
        `https://localhost:7269/api/Films/get-films-by-genre?genre=${genre}`
      )
        .then((response) => response.json())
        .then((data) => {
          if (data.isSuccess) {
            setFilms(data.result);
          } else {
            setError(data.errorMessages.join(", "));
          }
        })
        .catch((err) => setError(err.message));
    }
  };
  if (error) return <p>Error: {error}</p>;

  return (
    <div>
      <div className="my-4 mx-5">
        <div className="d-flex justify-content-between align-items-center">
          <div className="bg-lightblue d-flex  align-items-start p-3 ">
            <input
              type="text"
              value={searchQuery}
              onChange={(e) => setSearchQuery(e.target.value)}
              placeholder="Search..."
              className="btn shadow mx-1"
              style={{ backgroundColor: "white" }}
            />
            <select
              value={searchBy}
              onChange={(e) => setSearchBy(e.target.value)}
              className="form-select shadow mx-1"
            >
              <option value="title">Title</option>
              <option value="director">Director</option>
            </select>
          </div>
          <div style={{ marginTop: "-15px" }}>
            <a
              href="/films/add-film"
              className="btn text-dark shadow mx-1"
              style={{ backgroundColor: "#B0F2B8" }}
            >
              Add a new film <i class="bi bi-patch-plus"></i>
            </a>
          </div>
        </div>

        <div
          className="d-flex "
          style={{ marginTop: "-10px", marginLeft: "16px" }}
        >
          <select
            className="form-select shadow me-2"
            value={genre}
            onChange={(e) => setGenre(e.target.value)}
            style={{ maxWidth: "200px" }}
          >
            <option value="All">All</option>
            {genres.map((g) => (
              <option key={g} value={g}>
                {g}
              </option>
            ))}
          </select>
          <button
            className="btn shadow"
            onClick={fetchFilmsByGenre}
            style={{ backgroundColor: "#CAB0F2" }}
          >
            Filter by genre
          </button>
        </div>
        <div
          className="d-flex "
          style={{ marginLeft: "13px", marginTop: "20px" }}
        >
          <button
            className="btn shadow mx-1"
            onClick={fetchSortedFilms}
            style={{ backgroundColor: "#B0BEF2" }}
          >
            Sort by film rating{" "}
            {sortOrder === "asc" ? (
              <i class="bi bi-sort-down-alt"></i>
            ) : (
              <i class="bi bi-sort-up"></i>
            )}
          </button>
        </div>
      </div>

      <div className="my-4">
        <FilmsItemsList filmsList={filteredFilms} />
      </div>
    </div>
  );
}

export default Home;
