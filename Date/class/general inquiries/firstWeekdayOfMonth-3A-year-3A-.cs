firstWeekdayOfMonth: mn year: yr
	"Answer the weekday index (Sunday=1, etc) of the first day in the month named mn in the year yr."

	^(self newDay: 1 month: mn year: yr) weekdayIndex + 7 \\ 7 + 1