using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace MobilityTechTest.Models
{
	/// <summary>
    /// This class takes the JSON that OpenWeather outputs and parses it into useable data
    /// </summary>
	public class CurrentWeatherModel
	{
		public bool ValidData { get; }
		public int Cod { get; }
		public string Error { get; }
		public DateTime DataTime { get; }
		public string CityName { get; }
		public List<WeatherModel> Weather { get; } = new List<WeatherModel>();
		public MainModel Main { get; }
		public double Visibility { get; }
		public WindModel Wind { get; }
		public double Cloudiness { get; }
		public RainModel Rain { get; }
		public SnowModel Snow { get; }
		public DateTime Sunrise { get; }
		public DateTime Sunset { get; }
		[JsonIgnore] public WeatherModel CurrentWeather { get; }

		public CurrentWeatherModel(string json)
        {
			var data = JObject.Parse(json);

			if (data.SelectToken("cod").ToString() == "200")
            {
				ValidData = true;
				Cod = int.Parse(data.SelectToken("cod").ToString());

				DataTime = ConvertUnixToDateTime(double.Parse(data.SelectToken("dt").ToString()));
				CityName = data.SelectToken("name").ToString();
				foreach (JToken weather in data.SelectToken("weather")) Weather.Add(new WeatherModel(weather));
				CurrentWeather = Weather[0];
				Main = new MainModel(data.SelectToken("main"));
				if (data.SelectToken("visibility") != null) Visibility = double.Parse(data.SelectToken("visibility").ToString());
				Wind = new WindModel(data.SelectToken("wind	"));
				Cloudiness = double.Parse(data.SelectToken("clouds").SelectToken("all").ToString());
				if (data.SelectToken("rain") != null) Rain = new RainModel(data.SelectToken("rain"));
				if (data.SelectToken("snow") != null) Snow = new SnowModel(data.SelectToken("snow"));
				Sunrise = ConvertUnixToDateTime(double.Parse(data.SelectToken("sys").SelectToken("sunrise").ToString()));
				Sunset = ConvertUnixToDateTime(double.Parse(data.SelectToken("sys").SelectToken("sunset").ToString()));
			}
			else
            {
				ValidData = false;
				Cod = int.Parse(data.SelectToken("cod").ToString());
				Error = data.SelectToken("message").ToString();
			}
        }

		private static DateTime ConvertUnixToDateTime(double unixTime)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return dt.AddSeconds(unixTime).ToLocalTime();
		}
	}
}