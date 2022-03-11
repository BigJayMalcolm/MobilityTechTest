using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	public class WeatherModel
	{
		/// <summary>
		/// Weather condition id
		/// </summary>
		public int ID { get; }

		/// <summary>
		/// Group of weather parameters (Rain, Snow, Extreme etc.)
		/// </summary>
		public string Main { get; }

		/// <summary>
		/// Weather condition within the group
		/// </summary>
		public string Description { get; }

		/// <summary>
        /// Weather icon
        /// </summary>
		public string Icon { get; }

		public WeatherModel(JToken data)
		{
			ID = int.Parse(data.SelectToken("id").ToString());
			Main = data.SelectToken("main").ToString();
			Description = data.SelectToken("description").ToString();
			Icon = data.SelectToken("icon").ToString();
		}
	}
}