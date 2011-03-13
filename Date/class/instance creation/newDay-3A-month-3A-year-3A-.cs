newDay: day month: monthName year: year 
	"Answer an instance of me which is the day'th day of the month named 
	 monthName in the year'th year. The year may be specified as the actual 
	 number of years since the beginning of the Roman calendar or the 
	 number of years since 1900.  **Note** two digit dates are always from 1900.
		1/1/01 will NOT mean 2001."
	"Tolerate a month index instead of a month name."

	| monthIndex daysInMonth firstDayOfMonth |
	year < 100 ifTrue: [^ self
			newDay: day
			month: monthName
			year: 1900 + year].
	monthIndex _ monthName isInteger
	 ifTrue: [monthName] ifFalse: [self indexOfMonth: monthName].
	monthIndex = 2
		ifTrue: [daysInMonth _ (DaysInMonth at: monthIndex)
						+ (self leapYear: year)]
		ifFalse: [daysInMonth _ DaysInMonth at: monthIndex].
	monthIndex > 2
		ifTrue: [firstDayOfMonth _ (FirstDayOfMonth at: monthIndex)
						+ (self leapYear: year)]
		ifFalse: [firstDayOfMonth _ FirstDayOfMonth at: monthIndex].
	(day < 1 or: [day > daysInMonth])
		ifTrue: [self error: 'illegal day in month']
		ifFalse: [^self new day: day - 1 + firstDayOfMonth year: year]