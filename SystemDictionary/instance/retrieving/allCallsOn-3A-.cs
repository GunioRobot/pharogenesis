allCallsOn: aLiteral   "Smalltalk browseAllCallsOn: #open:label:."
	"Answer a Collection of all the methods that call on aLiteral."
	| aCollection special thorough aList |
	#(23 48 'fred' (new open:label:)) size.    "For testing!"
	aCollection _ OrderedCollection new.
	special _ self hasSpecialSelector: aLiteral ifTrueSetByte: [:byte ].
	thorough _ (aLiteral isMemberOf: Symbol)
				and: ["Possibly search for symbols imbedded in literal arrays"
					Preferences thoroughSenders].
	Cursor wait showWhile: 
		[self allBehaviorsDo: 
			[:class |
				aList _ thorough
					ifTrue:
			 			[(class thoroughWhichSelectorsReferTo: aLiteral special: special byte: byte)]
					ifFalse:
						[class whichSelectorsReferTo: aLiteral special: special byte: byte].
				aList do: 
					[:sel | sel ~~ #DoIt
						ifTrue: [aCollection add: class name , ' ' , sel]]]].
	^ aCollection