newTestVocabulary
	"Answer a Test vocabulary -- something to mess with, to illustrate and explore ideas."

	| aVocabulary  |
	aVocabulary _ Vocabulary new vocabularyName: #Test.
	aVocabulary documentation: 'An illustrative vocabulary for testing'.
	aVocabulary initializeFromTable:  #(
(isKindOf: none 	((aClass Class)) Boolean (#'class membership') 'answer whether the receiver''s superclass chain includes aClass')
(class none none Class (#'class membership' wimpy) 'answer the the class to which the receiver belongs')
(respondsTo: none ((aSelector Symbol))	Boolean (#'class membership') 'answer whether the receiver responds to the given selector')
(as:	none ((aClass Class)) Object (conversion) 'answer the receiver converted to be a member of aClass')).

	^ aVocabulary
"
	#((#'class membership' 	'Whether an object can respond to a given message, etc.' 	(isKindOf: class respondsTo:))
	(conversion 			'Messages to convert from one kind of object to another' 		(as:  asString))
	(copying				'Messages for making copies of objects'						(copy copyFrom:))
	(equality 				'Testing whether two objects are equal' 						( = ~= == ~~))
	(dependents				'Support for dependency notification'						(addDependent: removeDependent: release))) do:

		[:item | 
			aMethodCategory _ ElementCategory new categoryName: item first.
			aMethodCategory documentation: item second.
			item third do:
				[:aSelector | 
					aMethodInterface _ MethodInterface new initializeFor: aSelector.
					aVocabulary atKey: aSelector putMethodInterface: aMethodInterface.
					aMethodCategory elementAt: aSelector put: aMethodInterface].
			aVocabulary addCategory: aMethodCategory]."
