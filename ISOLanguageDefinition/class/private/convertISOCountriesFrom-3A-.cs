convertISOCountriesFrom: stream
	"Locale convertISOCountriesFrom: Locale isoCountries readStream "
	| line c3 c2 |
	^String streamContents: [:outStream |
	[stream atEnd
		or: [(line := stream nextLine readStream) atEnd]]
		whileFalse: [
			c3 := line upTo: Character tab.
			c2 := line upToEnd.
			outStream
				nextPutAll: c2; tab; nextPutAll: c3; cr]]