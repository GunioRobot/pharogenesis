numericParameterAtOneOf: alternateParameterNames ifAbsent: aBlock
	"Return the parameter named using one of the alternate names or an empty string"

	| parameterValue |
	parameterValue := self parameterAtOneOf: alternateParameterNames.
	parameterValue isEmpty
		ifTrue: [^aBlock value].
	^[Number readFrom: parameterValue] ifError: aBlock 

