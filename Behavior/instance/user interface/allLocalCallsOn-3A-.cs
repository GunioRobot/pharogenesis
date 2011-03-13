allLocalCallsOn: aSymbol
	"Answer a SortedCollection of all the methods that call on aSymbol, anywhere in my class hierarchy."

	| aSet special byte cls |
	aSet _ Set new.
	cls _ self theNonMetaClass.
	special _ self environment hasSpecialSelector: aSymbol
					ifTrueSetByte: [:b | byte _ b ].
	cls withAllSuperAndSubclassesDoGently: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte)
			do: [:sel |
				sel isDoIt ifFalse: [aSet add: class name , ' ', sel]]].
	cls class withAllSuperAndSubclassesDoGently: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte)
			do: [:sel |
				sel isDoIt ifFalse: [aSet add: class name , ' ', sel]]].
	^aSet