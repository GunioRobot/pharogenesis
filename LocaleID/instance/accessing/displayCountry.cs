displayCountry
	^(ISOLanguageDefinition isoCountries at: self isoCountry asUppercase ifAbsent: [ self isoCountry ]) 