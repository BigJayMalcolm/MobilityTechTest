using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	public class SnowModel
	{
		/// <summary>
		/// Snow volume for the last 1 hour, mm
		/// </summary>
		public double OneHour { get; }

		/// <summary>
		/// Snow volume for the last 3 hours, mm
		/// </summary>
		public double ThreeHour { get; }

		public SnowModel(JToken data)
		{
			if (data.SelectToken("1h") != null) OneHour = double.Parse(data.SelectToken("1h").ToString());
			if (data.SelectToken("3h") != null) ThreeHour = double.Parse(data.SelectToken("3h").ToString());
		}
	}
}