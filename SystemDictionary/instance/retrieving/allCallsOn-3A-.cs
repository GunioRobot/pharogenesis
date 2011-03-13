allCallsOn: aLiteral 
	"Answer a Collection of all the methods that call on aLiteral."
	| aCollection special methods |
	aCollection _ OrderedCollection new.
	special _ self hasSpecialSelector: aLiteral ifTrueSetByte: [:byte ].
	Cursor wait showWhile: 
		[self allBehaviorsDo: 
			[:class |
			 (class whichSelectorsReferTo: aLiteral special: special byte: byte) do: 
				[:sel | sel ~~ #DoIt
					ifTrue: [aCollection add: class name , ' ' , sel]]]].
	^aCollection