dayInMonth: monthIn year: yearIn ofFirstDayNamed: dayNameIn 
	"Private - Answer, the day in the month, monthIn, of year, yearIn, of 
	the first day named, dayNameIn."
	| frstDayNdx dayName firstDay |
	dayName := dayNameIn asSymbol.
	frstDayNdx := (Date firstWeekdayOfMonth: monthIn year: yearIn)
				- 1.
	frstDayNdx = 0 ifTrue: [frstDayNdx := frstDayNdx + 7].
	firstDay := 1.
	(Date nameOfDay: frstDayNdx)
		= dayName
		ifFalse: 
			[firstDay := 1 + (Date dayOfWeek: dayName) - frstDayNdx.
			firstDay < 1 ifTrue: [firstDay := firstDay + 7]].
	^ firstDay