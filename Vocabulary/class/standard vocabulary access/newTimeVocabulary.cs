newTimeVocabulary
	"Answer a Vocabulary object representing me" 
	| aVocabulary aMethodCategory aMethodInterface |
	"Vocabulary newTimeVocabulary"
	"Vocabulary addStandardVocabulary: Vocabulary newTimeVocabulary"

	aVocabulary _ self new vocabularyName: #Time.
	aVocabulary documentation: 'Time knows about hours, minutes, and seconds.  For long time periods, use Date'.

#((accessing 			'The basic info'
		(hours minutes seconds))
(arithmetic 				'Basic numeric operations'
		(addTime: subtractTime: max: min: min:max:))
(comparing				'Determining which is larger'
		(= < > <= >= ~= between:and:))
(testing 				'Testing'
		(ifNil: ifNotNil:))
(printing 				'Return a string for this Time'
		(hhmm24 print24 intervalString printMinutes printOn:))
(converting 			'Converting it to another form'
		(asSeconds asString))
(copying 				'Make another one like me'
		(copy))
) do: [:item | 
			aMethodCategory _ ElementCategory new categoryName: item first.
			aMethodCategory documentation: item second.
			item third do:
				[:aSelector | 
					aMethodInterface _ MethodInterface new initializeFor: aSelector.
					aVocabulary atKey: aSelector putMethodInterface: aMethodInterface.
					aMethodCategory elementAt: aSelector put: aMethodInterface].
			aVocabulary addCategory: aMethodCategory].
	#(#addTime: subtractTime: max: min: = < > <= >= ~= ) do: [:sel |
		(aVocabulary methodInterfaceAt: sel ifAbsent: [self error: 'fix this method']) 
			argumentVariables: (OrderedCollection with:
				(Variable new name: nil type: aVocabulary vocabularyName))].
	^ aVocabulary