asDate
	"Answer the first day of the week."
	^ Date
		newDay: self dayOfMonth
		month: self monthName
		year: self year