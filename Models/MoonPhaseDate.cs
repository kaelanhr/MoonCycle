using MoonCycle.Enums;

namespace MoonCycle.Models
{
	internal class MoonPhaseDate
	{
		public DateTime date { get; set; }
		public MoonPhase MoonPhase { get; set; }

		public MoonPhaseDate(DateTime date, MoonPhase moonPhase)
		{
			this.date = date;
			MoonPhase = moonPhase;
		}
	}
}
