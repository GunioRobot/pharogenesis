localeID
	"Answer the natural language for the project"

	| prev |
	^ self projectParameterAt: #localeID
		ifAbsentPut: [
			(prev := self previousProject)
				ifNotNil: [prev projectParameterAt: #localeID ifAbsent: [LocaleID current]]
				ifNil: [LocaleID current]]