using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	public class WindModel
	{
		/// <summary>
		/// Wind speed, meter/sec
		/// </summary>
		public double Speed { get; }

		/// <summary>
		/// Wind direction, degrees
		/// </summary>
		public double Direction { get; }

		/// <summary>
		/// Wind gust, meter/sec
		/// </summary>
		public double Gust { get; }

		public WindModel(JToken data)
		{
			Speed = double.Parse(data.SelectToken("speed").ToString());
			Direction = double.Parse(data.SelectToken("deg").ToString());

			if (data.SelectToken("gust") != null) Gust = double.Parse(data.SelectToken("gust").ToString());
		}
	}
}