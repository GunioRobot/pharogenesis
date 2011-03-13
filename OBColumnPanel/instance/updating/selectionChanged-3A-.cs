selectionChanged: ann
	ann column hasSelection
		ifTrue: [self selected: ann column]
		ifFalse: [self clearAfter: ann column]
