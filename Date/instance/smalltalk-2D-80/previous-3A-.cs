previous: dayName 
	"Answer the previous date whose weekday name is dayName."

	| days |
	days _ 7 + self weekdayIndex - (self class dayOfWeek: dayName) \\ 7.
	days = 0 ifTrue: [ days _ 7 ].
	^ self subtractDays: days
