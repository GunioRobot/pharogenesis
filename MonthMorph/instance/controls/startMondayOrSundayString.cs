startMondayOrSundayString
	^ Week startMonday
		ifTrue: ['start Sunday']
		ifFalse: ['start Monday']