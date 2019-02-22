using System;
using System.Linq;

namespace Lab1.Model
{
    class Program
    {
        static CinemaContext db = new CinemaContext();
        static void Main(string[] args)
        {
            DbInitializer.Initialize(db);
            Console.WriteLine("1. Выборка всех данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один»\n");
            Console.WriteLine("Какой сеанс: ");
            var places = db.Places.ToList();
            foreach (Place place in places)
                Console.WriteLine($"Сеанс: {place.Session} Номер места: {place.PlaceNumber} Занятость: {place.Employment} ");

            Console.WriteLine("\n2. Выборку данных из таблицы, стоящей в схеме базы данных нас сто-роне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей\n");
            Console.WriteLine("Сеансы,отфильтрованные по цене билета");
            var sessions = db.Sessions.Where(p => p.TicketPrice == 250.5).ToList();
            foreach (Session session in sessions)
                Console.WriteLine($"Дата: {session.Date} Начало сеанса: {session.TimeStarted} Конец сеанса: {session.EndTime} Цена билета: {session.TicketPrice} Сотрудники: {session.EmployessInvolvedInTheSession}");

            Console.WriteLine("\n3. Выборку данных, сгруппированных по любому из полей данных с выво-дом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных нас стороне отношения «многие»\n");
            Console.Write("Количество мест, которые свободны: ");
            var places1 = db.Places.ToList();

            Console.WriteLine(db.Places.Where(p => p.Employment == true).Count());

            Console.WriteLine("\n4. Выборку данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» \n");
            Console.WriteLine("Cеансы, запланированные на сегодня: ");
            var list1 = db.Sessions.Join(db.Places, p => p.PlaceId, c => c.PlaceId, (p, c) => new { Name = c.Session, c.Employment, SessionName = p.EmployessInvolvedInTheSession, p.TicketPrice });
            foreach (var item in list1)
                Console.WriteLine($"Сеанс: {item.Name} Занятость: {item.Employment} Сотрудники: {item.SessionName} Цена билета: {item.TicketPrice}");

            Console.WriteLine("\n5. Выборку данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значе-ния одного или нескольких полей \n");
            Console.WriteLine("Определенный фильм, а именно Лаллита:");
            list1 = db.Sessions.Join(db.Places, p => p.PlaceId, c => c.PlaceId, (p, c) => new { Name = c.Session, c.Employment, SessionName = p.EmployessInvolvedInTheSession, p.TicketPrice }).Where(p => p.Name == "Лаллита");
            foreach(var item in list1)
                Console.WriteLine($"Сеанс: {item.Name} Занятость: {item.Employment} Сотрудники: {item.SessionName} Цена билета: {item.TicketPrice}");

            Console.WriteLine("\n 6 и 8. Вставка и удаление данных в таблицы, стоящей на стороне отношения «Один>\n");
            Console.WriteLine("До добавления нового жанра: ");
            var genres = db.Genres.ToList();
            foreach (Genre genre in genres)
                Console.WriteLine($"Наименование: {genre.Name} Описание: {genre.Description}");

            Console.WriteLine("После добавления нового жанра: ");
            Genre genr = new Genre() { Name = "Триллер", Description = "Ужастик" };
            db.Genres.Add(genr);
            db.SaveChanges();
            genres = db.Genres.ToList();
            foreach (Genre genre in genres)
                Console.WriteLine($"Наименование: {genre.Name} Описание: {genre.Description}");
            Console.WriteLine("После удаления жанра: ");
            string name = "Триллер";
            var genre1 = db.Genres.Where(c => c.Name == name);
            db.Genres.RemoveRange(genre1);
            db.SaveChanges();
            genres = db.Genres.ToList();
            foreach (Genre genre in genres)
                Console.WriteLine($"Наименование: {genre.Name} Описание: {genre.Description}");

            Console.WriteLine("\n7 и 9. Вставку и удаление данных в таблицы, стоящей на стороне отношения «Многие» \n");
            Console.WriteLine("До добавления фильма: ");
            var films = db.Films.ToList();
            foreach (Film film in films)
                Console.WriteLine($"Наименование {film.Name} Жанр {film.Genre} Продолжительность {film.Duration} Компания {film.FilmCompany} Страна {film.ProducingCountry} Актеры {film.ListOfMainActros} Возраст {film.AgeRestrictions} Описание {film.Description}");

            Console.WriteLine("После добавления фильма: ");
            Film fil = new Film() { Name = "Простоквашино", Genre = "Мультфильм", Duration = new DateTime(2018, 07, 20, 14, 30, 00), FilmCompany = "ОАО", ProducingCountry = "Россия", ListOfMainActros = "Дядя Фёдор", AgeRestrictions = 6, Description = "Поучительный", GenreId = 1, SessionId = 1 };
            db.Films.Add(fil);
            db.SaveChanges();

            Console.WriteLine("После удаления фильма: ");
            string filmname = "Простоквашино";
            var film1 = db.Films.Where(c => c.Name == filmname);
            db.Films.RemoveRange(film1);
            db.SaveChanges();
            films = db.Films.ToList();
            foreach (Film film in films)
                Console.WriteLine($"Наименование {film.Name} Жанр {film.Genre} Продолжительность {film.Duration} Компания {film.FilmCompany} Страна {film.ProducingCountry} Актеры {film.ListOfMainActros} Возраст {film.AgeRestrictions} Описание {film.Description}");

            Console.WriteLine("\n10. Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных\n");
            Console.WriteLine("Места до обновления: ");
            places = db.Places.ToList();
            foreach (Place place in places)
                Console.WriteLine($"Id: {place.PlaceId} Сеанс: {place.Session} Номер места: {place.PlaceNumber} Занятость {place.Employment}");
            places = db.Places.Where(p => p.PlaceNumber == 26).ToList();
            foreach (Place place in places)
                place.PlaceNumber = 18;
            db.SaveChanges();
            Console.WriteLine("Места после обновления");
            places = db.Places.ToList();
            foreach (Place place in places)
                Console.WriteLine($"Id: {place.PlaceId} Сеанс: {place.Session} Номер места: {place.PlaceNumber} Занятость {place.Employment}");

            Console.ReadKey();
        }
    }
}
