typeForParameter
	"Answer a symbol representing the type of my parameter"

	scriptName numArgs > 0 ifTrue:
		[(playerScripted class scripts at: scriptName ifAbsent: [nil]) ifNotNilDo:
			[:aScript | ^ aScript argumentVariables first variableType]].

	^ #Error