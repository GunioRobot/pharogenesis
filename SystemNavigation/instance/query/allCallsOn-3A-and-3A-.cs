allCallsOn: firstLiteral and: secondLiteral
	"Answer a SortedCollection of all the methods that call on both aLiteral 
	and secondLiteral."

	| aCollection secondArray firstSpecial secondSpecial firstByte secondByte |
	self flag: #ShouldUseAllCallsOn:. "sd"
	aCollection := SortedCollection new.
	firstSpecial := Smalltalk hasSpecialSelector: firstLiteral ifTrueSetByte: [:b | firstByte := b].
	secondSpecial := Smalltalk hasSpecialSelector: secondLiteral ifTrueSetByte: [:b | secondByte := b].
	Cursor wait showWhile: [ self allBehaviorsDo: [:class |
			secondArray := class whichSelectorsReferTo: secondLiteral special: secondSpecial byte: secondByte.
			((class whichSelectorsReferTo: firstLiteral special: firstSpecial byte: firstByte) select: [:aSel | 
				(secondArray includes: aSel)]) do: [:sel | 
					aCollection add: (MethodReference class: class selector: sel)]]].
	^aCollection