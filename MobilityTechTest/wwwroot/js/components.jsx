class SearchList extends React.Component {
	render() {
		var url = this.props.url + "?searchTerm=";

		var searches = this.props.data.map(function (search) {
			var url2 = url + search;
			if (search != null) {
				return (
					<p><a href={url2}>{search}</a></p>
				);
			}
		});

		if (searches.length === 0) {
			return (
				<div>
					<h2 className="text-center">Previous Searches</h2>
					<p className="text-center">There is no search history.</p>
				</div>
			);
		}
		else {
			return (
				<div>
					<h2 className="text-center">Previous Searches</h2>
					<div className="text-center">
						{searches}
					</div>
				</div>
			);
        }
	}
};

class Search extends React.Component {
	constructor(props) {
		super(props);
		this.state = { city: '', country: '' };

		this.handleCityChange = this.handleCityChange.bind(this);
		this.handleCountryChange = this.handleCountryChange.bind(this);
		this.handleSubmit = this.handleSubmit.bind(this);
	}

	handleCityChange = event => {
		this.setState({ city: event.target.value });
	};

	handleCountryChange = event => {
		this.setState({ country: event.target.value });
	};

	handleSubmit = event => {
		event.preventDefault();

		if (this.state.city == '' || this.state.country == '') { return; }

		var url = this.props.url + "?searchTerm=" + this.state.city + "," + this.state.country;
		window.open(url, "_self");

		this.setState({ city: '', country: '' });
	};

	render() {
		return (
			<div className="row">
				<h2>Search for a forecast</h2>
				<form onSubmit={this.handleSubmit}>
					<label class="form-label">Enter a City and Country Code below and hit View Forecast</label>
					<div class="row">
						<div class="col-8">
							<input type="text" class="form-control" value={this.state.city} onChange={this.handleCityChange} placeholder="London" />
						</div>

						<div class="col-3">
							<input type="text" class="form-control" value={this.state.country} onChange={this.handleCountryChange} placeholder="GB" />
						</div>

						<div class="col-1">
							<input type="submit" class="btn btn-primary" value="View Forecast" />
						</div>
					</div>
				</form>
			</div>
		);
	}
};

class Forecast extends React.Component {
	constructor(props) {
		super(props);
	}

	render() {
		var weatherIcon = "http://openweathermap.org/img/wn/" + this.props.data.currentWeather.icon + "@2x.png";
		var temperature = Math.round(this.props.data.main.temperature);
		var feelsLike = Math.round(this.props.data.main.temperatureFeelsLike);

		return (
			<div>
				<h2 className="text-center">Weather Forecast for {this.props.data.cityName}</h2>
				<div className="row">
					<div className="col-3"></div>
					<div className="col-6">
						<div className="row">
							<div className="col-3">
								<img src={weatherIcon} />
							</div>
							<div className="col-6">
								<p className="text-center small"><br/>{this.props.data.currentWeather.main} ({this.props.data.currentWeather.description})<br/>
								{this.props.data.wind.speed} m/s wind at a direction of {this.props.data.wind.direction}°</p>
							</div>
							<div className="col-3 text-right">
								<h2>{temperature}°C</h2>
								<p className="small">Feels like {feelsLike}°C</p>
							</div>
						</div>
					</div>
					<div className="col-3"></div>
				</div>
				<a href={this.props.url}>Return to Home</a>
			</div>
		);
	}
};