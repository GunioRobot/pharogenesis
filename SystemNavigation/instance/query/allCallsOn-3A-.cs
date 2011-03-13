allCallsOn: aLiteral 
	"Answer a Collection of all the methods that call on aLiteral even deeply embedded in 
	literal array."
	"self new allCallsOn: #open:label:."
	| aCollection special thorough aList byte |
	aCollection := OrderedCollection new.
	special := Smalltalk
				hasSpecialSelector: aLiteral
				ifTrueSetByte: [:b | byte := b].
	thorough := aLiteral isSymbol.
	Cursor wait showWhile: [self allBehaviorsDo: [:class | 
					aList := thorough
								ifTrue: [class
										thoroughWhichSelectorsReferTo: aLiteral
										special: special
										byte: byte]
								ifFalse: [class
										whichSelectorsReferTo: aLiteral
										special: special
										byte: byte].
					aList do: [:sel | aCollection add: (MethodReference class: class selector: sel)]]].
	^ aCollection