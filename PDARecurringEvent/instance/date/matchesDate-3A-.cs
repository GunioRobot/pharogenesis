matchesDate: aDate 
	(firstDate isNil or: [firstDate > aDate]) ifTrue: [^false].
	(lastDate notNil and: [lastDate < aDate]) ifTrue: [^false].
	recurrence == #eachDay ifTrue: [^true].
	recurrence == #dayOfWeek ifTrue: [^aDate weekday = firstDate weekday].
	recurrence == #dayOfMonth 
		ifTrue: [^aDate dayOfMonth = firstDate dayOfMonth].
	recurrence == #dateOfYear 
		ifTrue: 
			[^aDate monthIndex = firstDate monthIndex 
				and: [aDate dayOfMonth = firstDate dayOfMonth]].
	recurrence == #nthWeekdayOfMonth 
		ifTrue: 
			[^aDate weekday = firstDate weekday 
				and: [(aDate dayOfMonth - 1) // 7 = ((firstDate dayOfMonth - 1) // 7)]].
	recurrence == #nthWeekdayOfMonthEachYear 
		ifTrue: 
			[^aDate monthIndex = firstDate monthIndex and: 
					[aDate weekday = firstDate weekday 
						and: [(aDate dayOfMonth - 1) // 7 = ((firstDate dayOfMonth - 1) // 7)]]]