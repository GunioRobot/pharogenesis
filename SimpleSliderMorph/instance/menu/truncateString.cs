truncateString
	^ truncate
		ifTrue:
			['turn off truncation']
		ifFalse:
			['turn on truncation']