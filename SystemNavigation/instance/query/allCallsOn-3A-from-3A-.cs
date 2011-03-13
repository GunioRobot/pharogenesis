allCallsOn: aSymbol from: aClass
	"Answer a SortedCollection of all the methods that call on aSymbol."

	| aSortedCollection special byte |
	aSortedCollection _ SortedCollection new.
	special _ aClass environment hasSpecialSelector: aSymbol ifTrueSetByte: [:b | byte _ b ].
	aClass withAllSubclassesDo: [ :class |
		(class whichSelectorsReferTo: aSymbol special: special byte: byte) do: [:sel |
			sel isDoIt ifFalse: [
				aSortedCollection add: (
					MethodReference new
						setStandardClass: class 
						methodSymbol: sel
				)
			]
		]
	].
	^aSortedCollection