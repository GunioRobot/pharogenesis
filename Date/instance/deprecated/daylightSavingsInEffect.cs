daylightSavingsInEffect
	"Return true if DST is observed at or after 2am on this day"
 
	self deprecated: 'Deprecated'.

	self dayMonthYearDo: 
		[ :day :month :year |
		(month < 4 or: [month > 10]) ifTrue: [^ false].  "False November through March"
		(month > 4 and: [month < 10]) ifTrue: [^ true].  "True May through September"
		month = 4
		ifTrue:	["It's April -- true on first Sunday or later"
				day >= 7 ifTrue: [^ true].  "Must be after"
				^ day > (self weekdayIndex \\ 7)]
		ifFalse: ["It's October -- false on last Sunday or later"
				day <= 24 ifTrue: [^ true].  "Must be before"
				^ day <= (24 + (self weekdayIndex \\ 7))]]