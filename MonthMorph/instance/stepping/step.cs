step

	todayCache = Date today
		ifFalse: [self highlightToday  "Only happens once a day"]