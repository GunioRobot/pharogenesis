localeID
	"Answer the natural language for the project"

	| prev |
	^ self projectParameterAt: #localeID
		ifAbsentPut: [
			(prev _ self previousProject)
				ifNotNil: [prev projectParameterAt: #localeID ifAbsent: [LocaleID default]]
				ifNil: [LocaleID default]]