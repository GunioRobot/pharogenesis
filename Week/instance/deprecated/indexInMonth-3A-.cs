indexInMonth: aMonth
	"1=first week, 2=second week, etc."

	self deprecated: 'obsolete'.

	^ (Date dayOfWeek: aMonth dayOfWeekName) + self dayOfMonth - 2  // 7 + 1
