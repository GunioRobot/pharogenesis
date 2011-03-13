trigger
	^ self isEnabled ifTrue: [self execute]