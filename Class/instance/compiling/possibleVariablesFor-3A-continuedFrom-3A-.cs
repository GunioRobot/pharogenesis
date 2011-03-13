possibleVariablesFor: misspelled continuedFrom: oldResults

	| results |
	results _ misspelled correctAgainstDictionary: self classPool continuedFrom: oldResults.
	self sharedPools do: [:pool | 
		results _ misspelled correctAgainstDictionary: pool continuedFrom: results ].
	superclass == nil
		ifTrue: 
			[ ^ misspelled correctAgainstDictionary: Smalltalk continuedFrom: results ]
		ifFalse:
			[ ^ superclass possibleVariablesFor: misspelled continuedFrom: results ]