descendingString
	^ self descending
		ifTrue:
			['switch to ascending']
		ifFalse:
			['switch to descending']