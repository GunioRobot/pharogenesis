allCallsOn: aLiteral 
	"Answer a Collection of all the methods that call on aLiteral even deeply embedded in 
	literal array."
	"self new browseAllCallsOn: #open:label:."
	| aCollection special thorough aList byte |
	aCollection _ OrderedCollection new.
	special _ Smalltalk
				hasSpecialSelector: aLiteral
				ifTrueSetByte: [:b | byte _ b].
	thorough _ (aLiteral isSymbol)
				and: ["Possibly search for symbols imbedded in literal arrays"
					Preferences thoroughSenders].
	Cursor wait
		showWhile: [self
				allBehaviorsDo: [:class | 
					aList _ thorough
								ifTrue: [class
										thoroughWhichSelectorsReferTo: aLiteral
										special: special
										byte: byte]
								ifFalse: [class
										whichSelectorsReferTo: aLiteral
										special: special
										byte: byte].
					aList
						do: [:sel | sel == #DoIt
								ifFalse: [aCollection
										add: (MethodReference new setStandardClass: class methodSymbol: sel)]]]].
	^ aCollection