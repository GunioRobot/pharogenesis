firstDayOfMonth
	"Answer the index of the day of the year that is the first day of the receiver's month."

	^(FirstDayOfMonth at: self monthIndex)
		+ (self monthIndex > 2
				ifTrue: [self leap]
				ifFalse: [0])