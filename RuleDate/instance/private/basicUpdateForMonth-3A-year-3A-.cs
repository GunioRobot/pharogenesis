basicUpdateForMonth: mm year: yyyy 
	"Private - Answer the receiver after updating by applying the rule for 
	the month, mm, of year, yyyy."
	| dayByRule daysNamedInMonth firstDayNamed |
	firstDayNamed := self
				dayInMonth: mm
				year: yyyy
				ofFirstDayNamed: dayOfWeek.

	daysNamedInMonth := (firstDayNamed to: self daysInMonth by: 7) asArray.
	dayByRule := self applyRuleTo: daysNamedInMonth.
	self start: (Date
				newDay: dayByRule
				month: mm
				year: yyyy).
