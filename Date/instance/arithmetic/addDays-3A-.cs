addDays: dayCount 
	"Answer a Date that is dayCount days after the receiver."

	^self class fromJulianDayNumber: self julianDayNumber + dayCount.