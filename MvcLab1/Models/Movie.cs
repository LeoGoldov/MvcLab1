using System.ComponentModel.DataAnnotations;

namespace MvcLab1.Models
{
    public class Movie
    {
        public Movie()
        {
            Title = string.Empty;
            Director = string.Empty;
            Genre = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Название фильма обязательно")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Название должно быть от 1 до 200 символов")]
        [Display(Name = "Название фильма")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Режиссер обязателен")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя режиссера должно быть от 2 до 100 символов")]
        [Display(Name = "Режиссер")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Год выпуска обязателен")]
        [Range(1895, 2026, ErrorMessage = "Год выпуска должен быть от 1895 до 2026")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Жанр должен быть от 3 до 50 символов")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Длительность обязательна")]
        [Range(1, 300, ErrorMessage = "Длительность должна быть от 1 до 300 минут")]
        [Display(Name = "Длительность (минуты)")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Рейтинг обязателен")]
        [Range(0, 10, ErrorMessage = "Рейтинг должен быть от 0 до 10")]
        [Display(Name = "Рейтинг")]
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public decimal Rating { get; set; }

        [Display(Name = "Доступен для просмотра")]
        public bool IsAvailable { get; set; }

        // Метод GetHours() - перевод длительности в часы и минуты
        [Display(Name = "Длительность")]
        public string GetHours()
        {
            int hours = Duration / 60;
            int minutes = Duration % 60;

            if (hours == 0)
                return $"{minutes} мин";
            else if (minutes == 0)
                return $"{hours} ч";
            else
                return $"{hours} ч {minutes} мин";
        }
    }
}