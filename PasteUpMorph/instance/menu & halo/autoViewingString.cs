autoViewingString
	^ self automaticViewing
		ifTrue:
			['stop automatic viewing']
		ifFalse:
			['start automatic viewing']
