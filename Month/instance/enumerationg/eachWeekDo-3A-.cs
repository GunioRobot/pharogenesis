eachWeekDo: aBlock
	| week |
	week _ self firstDate week.
	[week firstDate <= self lastDate]
		whileTrue:
			[aBlock value: week.
			week _ week next]