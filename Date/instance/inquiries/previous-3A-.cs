previous: dayName 
	"Answer the previous date whose weekday name is dayName."

	^self subtractDays: 7 + self weekdayIndex - (self class dayOfWeek: dayName) \\ 7