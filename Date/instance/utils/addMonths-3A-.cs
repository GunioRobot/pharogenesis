addMonths: monthCount 
	^ Date
		newDay: self dayOfMonth
		month: self month + monthCount - 1 \\ 12 + 1
		year: self year + (monthCount + self month - 1 // 12)