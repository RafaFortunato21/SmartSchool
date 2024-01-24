namespace SmartSchool.WebAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(age))
                age --;

            return age;
        }

        /// <summary>
        /// Retorna em anos o tempo de serviço.
        /// </summary>
        /// <returns></returns>
        public static int GetTimeOfService(this DateTime dateTime)
        {
            var currentDate = DateTime.UtcNow;
            int timeOfService = currentDate.Year - dateTime.Year;

            if (currentDate < dateTime.AddYears(timeOfService))
                timeOfService --;

            return timeOfService;

        }
    }
}