trackingPointerString
	^ (trackPointer
		ifTrue: ['stop tracking pointer']
		ifFalse: ['start tracking pointer']) translated