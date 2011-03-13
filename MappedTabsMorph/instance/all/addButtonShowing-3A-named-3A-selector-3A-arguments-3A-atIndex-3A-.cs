addButtonShowing: aString named: aName selector: aSymbol arguments: argList atIndex: anIndex

	| bb |
	bb _ super addButtonShowing: aString named: aName 
			selector: aSymbol arguments: argList atIndex: anIndex.
	tabsInOrder ifNil: [tabsInOrder _ OrderedCollection new].
	tabsInOrder addLast: bb.
	^ bb