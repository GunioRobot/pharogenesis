readISOCountriesFrom: stream
	"ISOLanguageDefinition readISOCountriesFrom: ISOLanguageDefinition isoCountryString readStream "
	| countries line |
	countries := Dictionary new.
	[stream atEnd
		or: [(line := stream nextLine readStream) atEnd]]
		whileFalse: [
			countries at: (line upTo: Character tab) put: line upToEnd].
	^countries