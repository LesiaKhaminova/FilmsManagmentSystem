function Header() {
  return (
    <header>
      <nav
        className="text-center p-3 text-white shadow"
        style={{ backgroundColor: "#463f3a" }}
      >
        <div className="container-fluid text-center">
          <p className="text-white fs-3">
            Film Managment System <i class="bi bi-camera-reels-fill"></i>
          </p>
        </div>
      </nav>
    </header>
  );
}

export default Header;
