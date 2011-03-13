readField: fieldName fromString: aString fields: sharedFields base: instVarBase
	"Overridden to check for valid recurrence symbol"

	fieldName = 'recurrence' ifTrue: [^ self recurrence: aString withBlanksTrimmed asSymbol].
	^ super readField: fieldName fromString: aString fields: sharedFields base: instVarBase
