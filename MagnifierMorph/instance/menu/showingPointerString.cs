showingPointerString
	^ (self showPointer
		ifTrue: ['stop showing pointer']
		ifFalse: ['start showing pointer']) translated