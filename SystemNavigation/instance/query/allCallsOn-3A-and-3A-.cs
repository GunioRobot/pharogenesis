allCallsOn: firstLiteral and: secondLiteral
	"Answer a SortedCollection of all the methods that call on both aLiteral 
	and secondLiteral."

	| aCollection secondArray firstSpecial secondSpecial firstByte secondByte |
	self flag: #ShouldUseAllCallsOn:. "sd"
	aCollection _ SortedCollection new.
	firstSpecial _ Smalltalk hasSpecialSelector: firstLiteral ifTrueSetByte: [:b | firstByte _ b].
	secondSpecial _ Smalltalk hasSpecialSelector: secondLiteral ifTrueSetByte: [:b | secondByte _ b].
	Cursor wait showWhile: [
		self allBehaviorsDo: [:class |
			secondArray _ class 
				whichSelectorsReferTo: secondLiteral
				special: secondSpecial
				byte: secondByte.
			((class whichSelectorsReferTo: firstLiteral special: firstSpecial byte: firstByte) select:
				[:aSel | (secondArray includes: aSel)]) do:
						[:sel | 
							aCollection add: (
								MethodReference new
									setStandardClass: class 
									methodSymbol: sel
							)
						]
		]
	].
	^aCollection