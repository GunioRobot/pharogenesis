displayLanguage
	| language |
	language := (ISOLanguageDefinition iso2LanguageDefinition: self isoLanguage) language.
	^self isoCountry
		ifNil: [language]
		ifNotNil: [language , ' (' , self displayCountry , ')']