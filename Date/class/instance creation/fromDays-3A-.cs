fromDays: dayCount
	"Answer an instance of me which is dayCount days after January 1, 1901.  Works for negative days before 1901.  Works over a huge range, both BC and AD."

	^self fromJulianDayNumber: dayCount +  2415386 "Julian Day Number of 1 Jan 1901" 
