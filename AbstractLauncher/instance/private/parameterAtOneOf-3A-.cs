parameterAtOneOf: alternateParameterNames
	| parameterName |
	"Return the parameter named using one of the alternate names or an empty string"

	parameterName := self determineParameterNameFrom: alternateParameterNames.
	^parameterName isNil
		ifTrue: ['']
		ifFalse: [self parameterAt: parameterName ifAbsent: ['']]