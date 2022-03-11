using System;
using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	public class MainModel
	{
		/// <summary>
        /// Current temperature in celsius
        /// </summary>
		public double Temperature { get; }

		/// <summary>
        /// What the temperature currently feels like in celsius
        /// </summary>
		public double TemperatureFeelsLike { get; }

		/// <summary>
		/// Minimum temperature at the moment in celsius
        /// This is minimal currently observed temperature (within large megalopolises and urban areas)
		/// </summary>
		public double TemperatureMin { get; }

		/// <summary>
		/// Maximum temperature at the moment in celsius
        /// This is maximal currently observed temperature (within large megalopolises and urban areas)
		/// </summary>
		public double TemperatureMax { get; }

		/// <summary>
		/// Atmospheric pressure (on the sea level, if there is no sea_level or grnd_level data), hPa
		/// </summary>
		public double Pressure { get; }

		/// <summary>
        /// Current himidity percentage
        /// </summary>
		public double Humidity { get; }

		/// <summary>
		/// Atmospheric pressure on the sea level, hPa
		/// </summary>
		public double SeaLevel { get; }

		/// <summary>
		/// Atmospheric pressure on the ground level, hPa
		/// </summary>
		public double GroundLevel { get; }

		public MainModel(JToken data)
		{
			// Using Math.Round to parse the kelvin temperature into celsius
			Temperature = Math.Round(double.Parse(data.SelectToken("temp").ToString()) - 273.15, 3);
			TemperatureFeelsLike = Math.Round(double.Parse(data.SelectToken("feels_like").ToString()) - 273.15, 3);
			TemperatureMin = Math.Round(double.Parse(data.SelectToken("temp_min").ToString()) - 273.15, 3);
			TemperatureMax = Math.Round(double.Parse(data.SelectToken("temp_max").ToString()) - 273.15, 3);
			Pressure = double.Parse(data.SelectToken("pressure").ToString());
			Humidity = double.Parse(data.SelectToken("humidity").ToString());
			if (data.SelectToken("sea_level") != null) SeaLevel = double.Parse(data.SelectToken("sea_level").ToString());
			if (data.SelectToken("grnd_level") != null) GroundLevel = double.Parse(data.SelectToken("grnd_level").ToString());
		}
	}
}