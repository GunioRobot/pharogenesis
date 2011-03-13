addButtonShowing: aString named: aName selector: aSymbol arguments: argList atIndex: anIndex

	| b indexToUse |
	b _ StringButtonMorph new.
	b	contents: aString;
		color: self buttonOffColor;
		target: self;
		actionSelector: aSymbol.
	argList ifNotNil: [b arguments: argList].
	b setNameTo: aName.
	indexToUse _ anIndex == nil ifTrue: [submorphs size + 1] ifFalse: [anIndex].
	self privateAddMorph: b atIndex: indexToUse.
	^ b
