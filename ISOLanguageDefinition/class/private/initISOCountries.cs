initISOCountries
	| countries |
	countries := self readISOCountriesFrom: self isoCountryString readStream.
	countries addAll: self extraCountryDefinitions.
	^countries