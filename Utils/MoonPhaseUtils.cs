using MoonCycle.Enums;

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

		public static MoonPhase GetMoonPhase(double daysSinceNewMoon) => daysSinceNewMoon switch
		{
			/*
			 * The moon phases were broken down to allow accuracy of each of the 4 milestones (New, First Quarter, Full, Last Quarter) within a day.
			 * I concur with the same conclusion as: https://minkukel.com/en/various/calculating-moon-phase/
			 */
			>= 0 and < 1 => MoonPhase.NEW_MOON,
			>= 1 and < 6.38264692644 => MoonPhase.WAXING_CRESCENT,
			>= 6.38264692644 and < 8.38264692644 => MoonPhase.FIRST_QUARTER,
			>= 8.38264692644 and < 13.76529385288 => MoonPhase.WAXING_GIBBOUS,
			>= 13.76529385288 and < 15.76529385288 => MoonPhase.FULL_MOON,
			>= 15.76529385288 and < 21.14794077932 => MoonPhase.WANING_GIBBOUS,
			>= 21.14794077932 and < 23.14794077932 => MoonPhase.LAST_QUARTER,
			>= 23.14794077932 and < 28.53058770576 => MoonPhase.WANING_CRESCENT,
			>= 28.53058770576 and < 29.53058770576 => MoonPhase.NEW_MOON,
			_ => MoonPhase.UNKNOWN
		};

		public static MoonPhase GetMoonPhase(DateTime date)
		{
			return GetMoonPhase(CalculateDaysSinceNewMoon(date));
		}

		public static string GetMoonPhaseString(MoonPhase moonPhase) => moonPhase switch
		{
			MoonPhase.NEW_MOON  => "New Moon",
			MoonPhase.WAXING_CRESCENT  => "Waxing Crescent",
			MoonPhase.FIRST_QUARTER  => "First Quarter",
			MoonPhase.WAXING_GIBBOUS  => "Waxing Gibbous",
			MoonPhase.FULL_MOON  => "Full Moon",
			MoonPhase.WANING_GIBBOUS  => "Waning Gibbous",
			MoonPhase.LAST_QUARTER  => "Last Quarter",
			MoonPhase.WANING_CRESCENT => "Waning Crescent",
			_ => "Unknown"
		};

		public static string GetMoonPhaseIcon(MoonPhase moonphase) => moonphase switch
		{
			MoonPhase.NEW_MOON => "new_moon",
			MoonPhase.WAXING_CRESCENT => "waxing_crescent",
			MoonPhase.FIRST_QUARTER => "first_quarter",
			MoonPhase.WAXING_GIBBOUS => "waxing_gibbous",
			MoonPhase.FULL_MOON => "full_moon",
			MoonPhase.WANING_GIBBOUS => "waning_gibbous",
			MoonPhase.LAST_QUARTER => "last_quarter",
			MoonPhase.WANING_CRESCENT => "waning_crescent",
			_ => "Unknown"
		};
	}
}
