typeforParameterFor: aSelector
	"Answer the type of the parameter for the given selector"

	(self class scripts at: aSelector ifAbsent: [nil]) ifNotNilDo:
		[:aScript | ^ aScript argumentVariables first variableType].
	self error: 'No parameter type for ', aSelector.
	^ #Number