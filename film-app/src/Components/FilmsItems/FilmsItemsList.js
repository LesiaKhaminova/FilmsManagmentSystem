import FilmItemCard from "./FilmItemCard";

function FilmsList({ filmsList }) {
  return (
    <div className="align-items-center mx-5">
      {filmsList.length > 0 ? (
        filmsList.map((film, id) => <FilmItemCard film={film} key={id} />)
      ) : (
        <div
          className="text-center text-danger display-5 fw-bold"
          style={{ marginTop: "200px" }}
        >
          <p>Ooops... Such films do not exist</p>
          <i class="bi bi-emoji-frown"></i>
        </div>
      )}
    </div>
  );
}

export default FilmsList;
