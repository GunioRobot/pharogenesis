addDays: dayCount 
	"Answer a Date that is dayCount days after the receiver."

	^Date newDay: day + dayCount
		  year: year