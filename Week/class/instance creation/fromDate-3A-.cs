fromDate: aDate
	| startDay |
	startDay _ aDate previous: (self startMonday 
								ifTrue: [#Monday] ifFalse: [#Sunday]).
	^ self
		newDay: startDay dayOfMonth
		month: startDay monthName
		year: startDay year