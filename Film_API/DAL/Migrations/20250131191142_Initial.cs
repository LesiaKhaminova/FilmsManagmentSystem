using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Description", "Director", "Genre", "Image", "Rating", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, "A mind-bending thriller where dreams and reality blend.", "Christopher Nolan", 5, "https://th.bing.com/th/id/OIP.Scqbt4kUs8tnBai7bT4ZTgHaEL?rs=1&pid=ImgDetMain", 9, 2010, "Inception" },
                    { 2, "Batman faces off against the Joker in a battle for Gotham.", "Christopher Nolan", 1, "https://th.bing.com/th/id/R.9dea9ababa3ad7f21359ffcb057faefd?rik=4Lk1jTgavlYEog&riu=http%3a%2f%2fwww.studioremarkable.com%2fwp-content%2fuploads%2f2012%2f08%2fDark-Knight-Trilogy.jpg&ehk=D%2bFvpPCEqUoo4GUlHzYK8Fz8RU8nkjeBz5q46V7PRwY%3d&risl=&pid=ImgRaw&r=0", 9, 2008, "The Dark Knight" },
                    { 3, "A computer hacker learns about the true nature of reality.", "The Wachowskis", 7, "https://th.bing.com/th/id/OIP.QdsZ5NsxPLcQPUrW4GkKQgHaEK?rs=1&pid=ImgDetMain", 8, 1999, "The Matrix" },
                    { 4, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", "Francis Ford Coppola", 0, "https://images5.alphacoders.com/131/1315822.jpg", 10, 1972, "The Godfather" },
                    { 5, "In Nazi-occupied Poland, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.", "Steven Spielberg", 2, "https://images5.alphacoders.com/341/thumb-1920-341183.jpg", 10, 1993, "Schindler's List" },
                    { 6, "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", "Quentin Tarantino", 7, "https://th.bing.com/th/id/OIP.UBzLyakmqVJXBPHmQasvGAHaEK?rs=1&pid=ImgDetMain", 9, 1994, "Pulp Fiction" },
                    { 7, "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "Robert Zemeckis", 4, "https://ntvb.tmsimg.com/assets/p15829_v_h8_aw.jpg?w=1280&h=720", 9, 1994, "Forrest Gump" },
                    { 8, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", "Frank Darabont", 2, "https://th.bing.com/th/id/R.304c3c3655c48e3985e5da998590713b?rik=DbOR8rxZiByAug&pid=ImgRaw&r=0", 10, 1994, "The Shawshank Redemption" },
                    { 9, "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", "Ridley Scott", 0, "https://static1.moviewebimages.com/wordpress/wp-content/uploads/2024/07/paul-mescal-in-gladiator-2.jpg", 8, 2000, "Gladiator" },
                    { 10, "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", "James Cameron", 4, "https://www.themoviedb.org/t/p/original/vIAm7UDNjGztvUYtDuS0in1VAXg.jpg", 8, 1997, "Titanic" },
                    { 11, "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.", "James Cameron", 6, "https://th.bing.com/th/id/R.fa78b5d06e0ed8f9723d8b7d9b26afc6?rik=JOCHURLPc%2f2YhA&pid=ImgRaw&r=0", 8, 2009, "Avatar" },
                    { 12, "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.", "Roger Allers, Rob Minkoff", 3, "https://townsquare.media/site/442/files/2016/09/lion-king.jpg?w=1200&h=0&zc=1&s=0&a=t&q=89", 9, 1994, "The Lion King" },
                    { 13, "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", "Steven Spielberg", 6, "https://orlandoinformer.com/wp-content/uploads/2020/06/Jurassic-park-gate-IOA.jpg", 8, 1993, "Jurassic Park" },
                    { 14, "An insomniac office worker, looking for a way to change his life, crosses paths with a devil-may-care soap maker, forming an underground fight club.", "David Fincher", 5, "https://images.indianexpress.com/2023/11/Poster-of-Fight-Club.jpg", 8, 1999, "Fight Club" },
                    { 15, "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to rescue Princess Leia from the clutches of the evil Empire.", "George Lucas", 4, "https://cdn.mos.cms.futurecdn.net/UB8sg7fS5tggpXXYrYyGHG-1200-80.jpg", 9, 1977, "Star Wars: Episode IV - A New Hope" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");
        }
    }
}
