textualTabString
	^ (self isCurrentlyTextual
		ifTrue: ['change tab wording...']
		ifFalse: ['use textual tab']) translated