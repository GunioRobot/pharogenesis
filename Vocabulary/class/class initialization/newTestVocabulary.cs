newTestVocabulary
	"Answer a Test vocabulary -- something to mess with, to illustrate and explore ideas."

	| aVocabulary  aMethodInterface aMethodCategory |
	aVocabulary _ Vocabulary new.

	aVocabulary vocabularyName: #Test.
	aVocabulary documentation: 'An illustrative vocabulary for testing'.

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
			aVocabulary addCategory: aMethodCategory].

	^ aVocabulary
