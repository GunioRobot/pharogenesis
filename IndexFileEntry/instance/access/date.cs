date
	"Answer a date string for this index entry."

	^Date fromDays: (time + (Date newDay: 1 year: 1980) asSeconds) // 86400