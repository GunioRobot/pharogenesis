isoCountries
	"ISOLanguageDefinition isoCountries"
	"ISOCountries := nil"

	^ISOCountries ifNil: [ISOCountries := self initISOCountries]