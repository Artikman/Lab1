using System;
using System.Linq;

namespace Lab1.Model
{
    class DbInitializer
    {
        public static void Initialize(CinemaContext db)
        {
            db.Database.EnsureCreated();

            // Проверка занесены ли данные о сеансах
            if (db.Sessions.Any()) return; // База данных инициализирована

            //Заполнение таблицы мест
            Place place1 = new Place() { Session = "Терминатор", PlaceNumber = 26, Employment = false };
            Place place2 = new Place() { Session = "СупеНянь", PlaceNumber = 5, Employment = true };
            Place place3 = new Place() { Session = "Гарри Поттер", PlaceNumber = 14, Employment = false };
            Place place4 = new Place() { Session = "Форсаж 8", PlaceNumber = 32, Employment = true };
            Place place5 = new Place() { Session = "Лаллита", PlaceNumber = 10, Employment = false };
            db.Places.AddRange(new Place[] { place1, place2, place3, place4, place5 });
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы сеансов
            Session session1 = new Session() { Date = new DateTime(2018, 07, 20), TimeStarted = new DateTime(2018, 07, 20, 14, 30, 00), EndTime = new DateTime(2018, 07, 20, 16, 30, 00), TicketPrice = 250.5f, EmployessInvolvedInTheSession = "Режиссёр", Places = place1 };
            Session session2 = new Session() { Date = new DateTime(2018, 07, 20), TimeStarted = new DateTime(2018, 07, 20, 14, 30, 00), EndTime = new DateTime(2018, 07, 20, 16, 30, 00), TicketPrice = 260.5f, EmployessInvolvedInTheSession = "Помощник", Places = place2 };
            Session session3 = new Session() { Date = new DateTime(2018, 07, 20), TimeStarted = new DateTime(2018, 07, 20, 14, 30, 00), EndTime = new DateTime(2018, 07, 20, 16, 30, 00), TicketPrice = 270.5f, EmployessInvolvedInTheSession = "Актёр", Places = place3 };
            Session session4 = new Session() { Date = new DateTime(2018, 07, 20), TimeStarted = new DateTime(2018, 07, 20, 14, 30, 00), EndTime = new DateTime(2018, 07, 20, 16, 30, 00), TicketPrice = 280.5f, EmployessInvolvedInTheSession = "Режиссёр", Places = place4 };
            Session session5 = new Session() { Date = new DateTime(2018, 07, 20), TimeStarted = new DateTime(2018, 07, 20, 14, 30, 00), EndTime = new DateTime(2018, 07, 20, 16, 30, 00), TicketPrice = 290.5f, EmployessInvolvedInTheSession = "Режиссёр", Places = place5 };
            db.Sessions.AddRange(new Session[] { session1, session2, session3, session4, session5 });
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы жанров
            Genre genre1 = new Genre() { Name = "Терминатор", Description = "Захватывающий" };
            Genre genre2 = new Genre() { Name = "СуперНянь", Description = "Смешной" };
            Genre genre3 = new Genre() { Name = "Гарри Поттер", Description = "Оригинальный" };
            Genre genre4 = new Genre() { Name = "Форсаж 8", Description = "Эпичный" };
            Genre genre5 = new Genre() { Name = "Лаллита", Description = "Трогательный" };
            db.Genres.AddRange(new Genre[] { genre1, genre2, genre3, genre4, genre5 });
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();

            //Заполнение таблицы фильмов
            Film film1 = new Film() { Name = "Терминатор", Genre = "Боевик", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "США", ListOfMainActros = "Арнольд Шварценеггер", AgeRestrictions = 12, Description = "Захватывающий", Sessions = session1, Genres = genre1 };
            Film film2 = new Film() { Name = "СуперНянь", Genre = "Комедия", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "США", ListOfMainActros = "Стив Конгсман", AgeRestrictions = 16, Description = "Смешной", Sessions = session2, Genres = genre2 };
            Film film3 = new Film() { Name = "Гарри Поттер", Genre = "Фантастика", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "США", ListOfMainActros = "Гарри Луиз", AgeRestrictions = 12, Description = "Оригинальный", Sessions = session3, Genres = genre3 };
            Film film4 = new Film() { Name = "Форсаж 8", Genre = "Гонка", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "США", ListOfMainActros = "Вин Дизель", AgeRestrictions = 14, Description = "Эпичный", Sessions = session4, Genres = genre4 };
            Film film5 = new Film() { Name = "Лаллита", Genre = "Мелодрама", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "США", ListOfMainActros = "Лаллита Морган", AgeRestrictions = 12, Description = "Трогательный", Sessions = session5, Genres = genre5 };
            db.Films.AddRange(new Film[] { film1, film2, film3, film4, film5 });
            //сохранение изменений в базу данных, связанную с объектом контекста
            db.SaveChanges();
        }
    }
}
