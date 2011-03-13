allLocalCallsOn: aSymbol
	"Answer a SortedCollection of all the methods that call on aSymbol, anywhere in my class hierarchy."

	| aSet special byte cls |
	aSet := Set new.
	cls := self theNonMetaClass.
	special := self environment hasSpecialSelector: aSymbol
					ifTrueSetByte: [:b | byte := b ].
	cls withAllSuperAndSubclassesDoGently: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte)
			do: [:sel |
				sel isDoIt ifFalse: [aSet add: class name , ' ', sel]]].
	cls class withAllSuperAndSubclassesDoGently: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte)
			do: [:sel |
				sel isDoIt ifFalse: [aSet add: class name , ' ', sel]]].
	^aSet