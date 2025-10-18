var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("hello/{name}", (string name) => $"Hello, {name}!");
app.MapGet("Hello/{name}/{age}", (string name, int age) => $"Hello, {name}, you're {age} years old!");
//app.Run();
List<Book> books = new()
{
    new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, 4.2, "Fiction"),
    new Book("To Kill a Mockingbird", "Harper Lee", 1960, 4.3, "Fiction"),
    new Book("1984", "George Orwell", 1949, 4.4, "Dystopian"),
    new Book("Pride and Prejudice", "Jane Austen", 1813, 4.5, "Romance"),
    new Book("The Catcher in the Rye", "J.D. Salinger", 1951, 3.9, "Fiction")
};
app.MapGet("books", () => books);
app.MapPost("/books", (Book book) =>
{
    books.Add(book);
    return Results.Ok();
});
app.MapGet("books/search", (string? author, int? year, double? minRating) =>
{
    var result = $"Szukam ksi¹¿ek: ";
    if (author != null)
    {
        result += $"Autor: {author} ";
    }
    if (year != null)
    {
        result += $"Rok: {year} ";
    }
    if (minRating != null)
    {
        result += $"ocena: {minRating} ";
    }
    return result;
});
app.Run();
public record Book(string Title, string Author, int Year, double Rating, string Gende);


