indexInMonth: aMonth
	"1=first week, 2=second week, etc."
	^ (Date dayOfWeek: aMonth weekday) + self dayOfMonth - 2  // 7 + 1