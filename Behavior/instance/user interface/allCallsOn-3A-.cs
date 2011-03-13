allCallsOn: aSymbol
	"Answer a SortedCollection of all the methods that call on aSymbol."

	| aSortedCollection special |
	aSortedCollection _ SortedCollection new.
	special _ Smalltalk hasSpecialSelector: aSymbol ifTrueSetByte: [:byte ].
	self withAllSubclassesDo:
		[:class | (class whichSelectorsReferTo: aSymbol special: special byte: byte) do:
			[:sel | sel ~~ #DoIt ifTrue: [aSortedCollection add: class name , ' ' , sel]]].
	^aSortedCollection