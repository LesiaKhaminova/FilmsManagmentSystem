﻿// <auto-generated />
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.BaseEntities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A mind-bending thriller where dreams and reality blend.",
                            Director = "Christopher Nolan",
                            Genre = 5,
                            Image = "https://th.bing.com/th/id/OIP.Scqbt4kUs8tnBai7bT4ZTgHaEL?rs=1&pid=ImgDetMain",
                            Rating = 9,
                            ReleaseYear = 2010,
                            Title = "Inception"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Batman faces off against the Joker in a battle for Gotham.",
                            Director = "Christopher Nolan",
                            Genre = 1,
                            Image = "https://th.bing.com/th/id/R.9dea9ababa3ad7f21359ffcb057faefd?rik=4Lk1jTgavlYEog&riu=http%3a%2f%2fwww.studioremarkable.com%2fwp-content%2fuploads%2f2012%2f08%2fDark-Knight-Trilogy.jpg&ehk=D%2bFvpPCEqUoo4GUlHzYK8Fz8RU8nkjeBz5q46V7PRwY%3d&risl=&pid=ImgRaw&r=0",
                            Rating = 9,
                            ReleaseYear = 2008,
                            Title = "The Dark Knight"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A computer hacker learns about the true nature of reality.",
                            Director = "The Wachowskis",
                            Genre = 7,
                            Image = "https://th.bing.com/th/id/OIP.QdsZ5NsxPLcQPUrW4GkKQgHaEK?rs=1&pid=ImgDetMain",
                            Rating = 8,
                            ReleaseYear = 1999,
                            Title = "The Matrix"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                            Director = "Francis Ford Coppola",
                            Genre = 0,
                            Image = "https://images5.alphacoders.com/131/1315822.jpg",
                            Rating = 10,
                            ReleaseYear = 1972,
                            Title = "The Godfather"
                        },
                        new
                        {
                            Id = 5,
                            Description = "In Nazi-occupied Poland, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                            Director = "Steven Spielberg",
                            Genre = 2,
                            Image = "https://images5.alphacoders.com/341/thumb-1920-341183.jpg",
                            Rating = 10,
                            ReleaseYear = 1993,
                            Title = "Schindler's List"
                        },
                        new
                        {
                            Id = 6,
                            Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                            Director = "Quentin Tarantino",
                            Genre = 7,
                            Image = "https://th.bing.com/th/id/OIP.UBzLyakmqVJXBPHmQasvGAHaEK?rs=1&pid=ImgDetMain",
                            Rating = 9,
                            ReleaseYear = 1994,
                            Title = "Pulp Fiction"
                        },
                        new
                        {
                            Id = 7,
                            Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                            Director = "Robert Zemeckis",
                            Genre = 4,
                            Image = "https://ntvb.tmsimg.com/assets/p15829_v_h8_aw.jpg?w=1280&h=720",
                            Rating = 9,
                            ReleaseYear = 1994,
                            Title = "Forrest Gump"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                            Director = "Frank Darabont",
                            Genre = 2,
                            Image = "https://th.bing.com/th/id/R.304c3c3655c48e3985e5da998590713b?rik=DbOR8rxZiByAug&pid=ImgRaw&r=0",
                            Rating = 10,
                            ReleaseYear = 1994,
                            Title = "The Shawshank Redemption"
                        },
                        new
                        {
                            Id = 9,
                            Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                            Director = "Ridley Scott",
                            Genre = 0,
                            Image = "https://static1.moviewebimages.com/wordpress/wp-content/uploads/2024/07/paul-mescal-in-gladiator-2.jpg",
                            Rating = 8,
                            ReleaseYear = 2000,
                            Title = "Gladiator"
                        },
                        new
                        {
                            Id = 10,
                            Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                            Director = "James Cameron",
                            Genre = 4,
                            Image = "https://www.themoviedb.org/t/p/original/vIAm7UDNjGztvUYtDuS0in1VAXg.jpg",
                            Rating = 8,
                            ReleaseYear = 1997,
                            Title = "Titanic"
                        },
                        new
                        {
                            Id = 11,
                            Description = "A paraplegic marine dispatched to the moon Pandora on a unique mission becomes torn between following his orders and protecting the world he feels is his home.",
                            Director = "James Cameron",
                            Genre = 6,
                            Image = "https://th.bing.com/th/id/R.fa78b5d06e0ed8f9723d8b7d9b26afc6?rik=JOCHURLPc%2f2YhA&pid=ImgRaw&r=0",
                            Rating = 8,
                            ReleaseYear = 2009,
                            Title = "Avatar"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Lion prince Simba and his father are targeted by his bitter uncle, who wants to ascend the throne himself.",
                            Director = "Roger Allers, Rob Minkoff",
                            Genre = 3,
                            Image = "https://townsquare.media/site/442/files/2016/09/lion-king.jpg?w=1200&h=0&zc=1&s=0&a=t&q=89",
                            Rating = 9,
                            ReleaseYear = 1994,
                            Title = "The Lion King"
                        },
                        new
                        {
                            Id = 13,
                            Description = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.",
                            Director = "Steven Spielberg",
                            Genre = 6,
                            Image = "https://orlandoinformer.com/wp-content/uploads/2020/06/Jurassic-park-gate-IOA.jpg",
                            Rating = 8,
                            ReleaseYear = 1993,
                            Title = "Jurassic Park"
                        },
                        new
                        {
                            Id = 14,
                            Description = "An insomniac office worker, looking for a way to change his life, crosses paths with a devil-may-care soap maker, forming an underground fight club.",
                            Director = "David Fincher",
                            Genre = 5,
                            Image = "https://images.indianexpress.com/2023/11/Poster-of-Fight-Club.jpg",
                            Rating = 8,
                            ReleaseYear = 1999,
                            Title = "Fight Club"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to rescue Princess Leia from the clutches of the evil Empire.",
                            Director = "George Lucas",
                            Genre = 4,
                            Image = "https://cdn.mos.cms.futurecdn.net/UB8sg7fS5tggpXXYrYyGHG-1200-80.jpg",
                            Rating = 9,
                            ReleaseYear = 1977,
                            Title = "Star Wars: Episode IV - A New Hope"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
