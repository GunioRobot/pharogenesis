indicateCursorString
	^ self indicateCursor
		ifTrue:
			['stop indicating cursor']
		ifFalse:
			['start indicating cursor']
