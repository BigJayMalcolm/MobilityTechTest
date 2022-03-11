
using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	public class RainModel
	{
		/// <summary>
		/// Rain volume for the last 1 hour, mm
		/// </summary>
		public double OneHour { get; }

		/// <summary>
		/// Rain volume for the last 3 hours, mm
		/// </summary>
		public double ThreeHour { get; }

		public RainModel(JToken data)
		{
			if (data.SelectToken("1h") != null) OneHour = double.Parse(data.SelectToken("1h").ToString());
			if (data.SelectToken("3h") != null) ThreeHour = double.Parse(data.SelectToken("3h").ToString());
		}
	}
}