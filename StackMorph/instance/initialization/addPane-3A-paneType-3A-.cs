addPane: aPane paneType: aType
	| anIndex |
	anIndex _ self insertionIndexForPaneOfType: aType.
	self privateAddMorph: aPane atIndex: anIndex