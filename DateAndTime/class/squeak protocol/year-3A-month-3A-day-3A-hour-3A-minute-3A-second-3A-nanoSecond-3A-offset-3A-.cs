year: year month: month day: day hour: hour minute: minute second: second nanoSecond: nanoCount offset: offset
	"Return a DateAndTime"

	| monthIndex daysInMonth p q r s julianDayNumber since |

	monthIndex _ month isInteger ifTrue: [month] ifFalse: [Month indexOfMonth: month].
	daysInMonth _ Month
		daysInMonth: monthIndex
		forYear: year.
	day < 1 ifTrue: [self error: 'day may not be zero or negative'].
	day > daysInMonth ifTrue: [self error: 'day is after month ends']. 	
	
	p _ (monthIndex - 14) quo: 12.
	q _ year + 4800 + p.
	r _ monthIndex - 2 - (12 * p).
	s _ (year + 4900 + p) quo: 100.

	julianDayNumber _
 		( (1461 * q) quo: 4 ) +
			( (367 * r) quo: 12 ) -
 				( (3 * s) quo: 4 ) +
 					( day - 32075 ).

	since _ Duration days: julianDayNumber hours: hour 
				minutes: minute seconds: second nanoSeconds: nanoCount.

	^ self basicNew
 		ticks: since ticks offset: offset;
		yourself.