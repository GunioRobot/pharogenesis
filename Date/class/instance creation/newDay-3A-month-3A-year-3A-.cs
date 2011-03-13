newDay: day month: month year: year 
	"Arguments day, month and year are all integers, except month may be a string.
	For compatibility, two digit dates in the range 00..49 are from 2000, 50..99 from 1900.
	Please use ALWAYS four digits year numbers."

	| monthIndex daysInMonth p q r s |

	year < 100 ifTrue: [^self
			newDay: day
			month: month
			year: (year < 50 ifTrue: [2000] ifFalse: [1900]) + year].

	monthIndex _ month isInteger ifTrue: [month] ifFalse: [self indexOfMonth: month].
	monthIndex = 2
		ifTrue: [ daysInMonth _ (DaysInMonth at: monthIndex) + (self leapYear: year) ]
		ifFalse: [ daysInMonth _ DaysInMonth at: monthIndex ].
	(day < 1 or: [day > daysInMonth]) ifTrue: [ self error: 'illegal day in month' ].

	p _ (monthIndex - 14) quo: 12.
	q _ year + 4800 + p.
	r _ monthIndex - 2 - (12 * p).
	s _ (year + 4900 + p) quo: 100.
 
	^self fromJulianDayNumber: 
		( (1461 * q) quo: 4 ) + 
			( (367 * r) quo: 12 ) - 
				( (3 * s) quo: 4 ) + 
					( day - 32075 )