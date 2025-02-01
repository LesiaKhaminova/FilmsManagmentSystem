import React from "react";
import { Header, Footer } from "../Components/Layout";
import { Route, Routes } from "react-router-dom";
import { NotFound } from "../Pages";
import { FilmItemDetails, Home, UpdateOrAddFilmDetails } from "../Pages";

function App() {
  return (
    <div
      className="d-flex flex-column"
      style={{ minHeight: "100vh", backgroundColor: "#edede9" }}
    >
      <Header />
      <div
        className="flex-grow-1"
        style={{ overflowY: "auto", paddingBottom: "60px" }}
      >
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/films/:id" element={<FilmItemDetails />} />
          <Route path="*" element={<NotFound />} />
          <Route
            path="/films/update-film/:id"
            element={<UpdateOrAddFilmDetails />}
          />
          <Route path="/films/add-film" element={<UpdateOrAddFilmDetails />} />
        </Routes>
      </div>
      <Footer />
    </div>
  );
}

export default App;
