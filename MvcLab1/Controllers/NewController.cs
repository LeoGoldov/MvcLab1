using Microsoft.AspNetCore.Mvc;

namespace MvcLab1.Controllers
{
    public class NewsController : Controller
    {
        // Главная страница с новостями
        public IActionResult Latest()
        {
            //список новостей
            ViewBag.NewsTitles = new List<string>
            {
                "Открытие нового парка",
                "Запуск космического корабля",
                "Новый рекорд в спорте",
                "Фестиваль искусств",
                "Снижение цен на электромобили"
            };

            ViewBag.NewsDates = new List<string>
            {
                "18.02.2026",
                "17.02.2026",
                "16.02.2026",
                "15.02.2026",
                "14.02.2026"
            };

            ViewBag.NewsCategories = new List<string>
            {
                "City",
                "Science",
                "Sport",
                "Culture",
                "Economy"
            };

            // Короткое описание для каждой новости
            ViewBag.NewsSummaries = new List<string>
            {
                "В центре города открылся новый парк...",
                "Корабль успешно запущен к Марсу...",
                "Спортсмен побил мировой рекорд...",
                "Выходные пройдут с искусством...",
                "Цены упали на 15%..."
            };

            ViewData["Title"] = "Последние новости";
            ViewData["NewsCount"] = 5;

            return View();
        }

        // Детальная страница новости
        public IActionResult Article(int id)
        {
            // Проверяем, есть ли такая новость (от 1 до 5)
            if (id < 1 || id > 5)
            {
                ViewBag.ErrorMessage = "Новость не найдена!";
                return View("Error");
            }

            // Заполняем данные в зависимости от id
            if (id == 1)
            {
                ViewBag.Title = "Открытие нового парка";
                ViewBag.Date = "18.02.2026";
                ViewBag.Category = "City";
                ViewBag.Content = "Вчера состоялось открытие нового парка в центре города. " +
                                  "В первый день парк посетило 5000 человек.";
                ViewBag.Author = "Анна Петрова";
            }
            else if (id == 2)
            {
                ViewBag.Title = "Запуск космического корабля";
                ViewBag.Date = "17.02.2026";
                ViewBag.Category = "Science";
                ViewBag.Content = "Сегодня запустили космический корабль к Марсу. " +
                                  "Он доставит на орбиту исследовательский модуль. " +
                                  "Ученые будут изучать атмосферу планеты. " +
                                  "Полет займет 8 месяцев.";
                ViewBag.Author = "Иван Сидоров";
            }
            else if (id == 3)
            {
                ViewBag.Title = "Новый рекорд в спорте";
                ViewBag.Date = "16.02.2026";
                ViewBag.Category = "Sport";
                ViewBag.Content = "Российский спортсмен установил мировой рекорд " +
                                  "в беге на 100 метров. Результат - 9.58 секунды. " +
                                  "Это на 0.02 секунды лучше предыдущего рекорда. " +
                                  "Спортсмен очень счастлив победе на домашнем стадионе.";
                ViewBag.Author = "Петр Смирнов";
            }
            else if (id == 4)
            {
                ViewBag.Title = "Фестиваль искусств";
                ViewBag.Date = "15.02.2026";
                ViewBag.Category = "Culture";
                ViewBag.Content = "С 20 по 22 февраля пройдет фестиваль искусств. " +
                                  "Будут выставки художников, концерты и театр. " +
                                  "Фестиваль откроется на главной площади. " +
                                  "Вход на все мероприятия свободный.";
                ViewBag.Author = "Елена Васильева";
            }
            else if (id == 5)
            {
                ViewBag.Title = "Снижение цен на электромобили";
                ViewBag.Date = "14.02.2026";
                ViewBag.Category = "Economy";
                ViewBag.Content = "Компания 'ЭлектроМобиль' снизила цены на 15%. " +
                                  "Теперь самая дешевая модель стоит 2.5 млн рублей. " +
                                  "Это из-за своего производства аккумуляторов. " +
                                  "Продажи должны вырасти на 30% в этом году.";
                ViewBag.Author = "Дмитрий Козлов";
            }

            ViewBag.NewsId = id;
            ViewData["Title"] = ViewBag.Title;

            // Простые хлебные крошки
            ViewBag.CurrentPage = "article";
            ViewBag.CurrentCategory = ViewBag.Category;

            return View();
        }

        // Новости по категориям
        public IActionResult Category(string category)
        {
            ViewBag.CurrentCategory = category;
            ViewData["Title"] = "Категория: " + category;

            // Простой список новостей для каждой категории
            if (category == "City")
            {
                ViewBag.CategoryNews = new List<string> { "Открытие нового парка", "Ремонт дорог", "Новая школа" };
                ViewBag.CategoryDates = new List<string> { "18.02.2026", "13.02.2026", "12.02.2026" };
            }
            else if (category == "Science")
            {
                ViewBag.CategoryNews = new List<string> { "Запуск корабля к Марсу", "Научная конференция" };
                ViewBag.CategoryDates = new List<string> { "17.02.2026", "11.02.2026" };
            }
            else if (category == "Sport")
            {
                ViewBag.CategoryNews = new List<string> { "Новый рекорд в беге", "Футбольный матч", "Хоккей" };
                ViewBag.CategoryDates = new List<string> { "16.02.2026", "10.02.2026", "09.02.2026" };
            }
            else if (category == "Culture")
            {
                ViewBag.CategoryNews = new List<string> { "Фестиваль искусств", "Выставка картин", "Концерт" };
                ViewBag.CategoryDates = new List<string> { "15.02.2026", "08.02.2026", "07.02.2026" };
            }
            else if (category == "Economy")
            {
                ViewBag.CategoryNews = new List<string> { "Снижение цен", "Курс доллара", "Биржа" };
                ViewBag.CategoryDates = new List<string> { "14.02.2026", "06.02.2026", "05.02.2026" };
            }
            else
            {
                ViewBag.CategoryNews = new List<string>();
                ViewBag.CategoryDates = new List<string>();
            }

            // Простые хлебные крошки
            ViewBag.CurrentPage = "category";

            return View();
        }

        // Страница с ошибкой
        public IActionResult Error()
        {
            ViewData["Title"] = "Ошибка";
            return View();
        }
    }
}