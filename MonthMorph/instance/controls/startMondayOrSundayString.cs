startMondayOrSundayString
	^(Week startDay  ifTrue: ['start Sunday'] ifFalse: ['start Monday']) 
		translated