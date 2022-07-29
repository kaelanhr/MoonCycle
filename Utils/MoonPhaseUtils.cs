namespace MoonCycle.Utils
{
	static class MoonphaseUtils
	{
		public static double CalculateDaysSinceNewMoon(DateTime date)
		{
			/*
			 * Formula acquired from: https://www.subsystems.us/uploads/9/8/9/4/98948044/moonphase.pdf
			 */
			var a = date.Year / 100;
			var b = a / 4;
			var c = 2 - a + b;
			var e = 365.25 * (date.Year + 4716);
			var f = 30.6001 * (date.Month + 1);
			var jd = c + date.Day + e + f - 1524.5;

			var daysSinceNew = jd - 2451549.5;
			var newMoons = daysSinceNew / 29.53;

			return (newMoons - Math.Truncate(newMoons)) * 29.53;
		}

		public static string GetMoonPhase(double daysSinceNewMoon) => daysSinceNewMoon switch
		{
			/*
			 * The moon phases were broken down to allow accuracy of each of the 4 milestones (New, First Quarter, Full, Last Quarter) within a day.
			 * I concur with the same conclusion as: https://minkukel.com/en/various/calculating-moon-phase/
			 */
			>= 0 and < 1 => "New Moon",
			>= 1 and < 6.38264692644 => "Waxing Crescent",
			>= 6.38264692644 and < 8.38264692644 => "First Quarter",
			>= 8.38264692644 and < 13.76529385288 => "Waxing Gibbous",
			>= 13.76529385288 and < 15.76529385288 => "Full Moon",
			>= 15.76529385288 and < 21.14794077932 => "Waning Gibbous",
			>= 21.14794077932 and < 23.14794077932 => "Last Quarter",
			>= 23.14794077932 and < 28.53058770576 => "Waning Crescent",
			>= 28.53058770576 and < 29.53058770576 => "New Moon",
			_ => "Unknown"
		};

		public static string GetMoonPhaseIcon(string moonphase) => moonphase switch
		{
			"New Moon" => "new_moon",
			"Waxing Crescent" => "waxing_crescent",
			"First Quarter" => "first_quarter",
			"Waxing Gibbous" => "waxing_gibbous",
			"Full Moon" => "full_moon",
			"Waning Gibbous" => "waning_gibbous",
			"Last Quarter" => "last_quarter",
			"Waning Crescent" => "waning_crescent",
			_ => "Unknown"
		};
	}
}
