allCallsOn: aSymbol from: aClass
	"Answer a SortedCollection of all the methods that call on aSymbol."

	| aSortedCollection special byte |
	aSortedCollection := SortedCollection new.
	special := aClass environment hasSpecialSelector: aSymbol ifTrueSetByte: [:b | byte := b ].
	aClass withAllSubclassesDo: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte) do: [:sel |
				aSortedCollection add: (MethodReference class: class selector: sel)]].
	^aSortedCollection