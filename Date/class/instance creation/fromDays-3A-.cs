fromDays: dayCount
	"Answer an instance of me which is dayCount days after January 1, 
	1901."

	^self
		newDay: 1 + (dayCount asInteger rem: 1461)
							"There are 1461 days in a 4-year cycle. 
							 2000 is a leap year, so no extra correction is necessary. "
		year: 1901 + ((dayCount asInteger quo: 1461) * 4)