testYearDayHourMinuteSecond
	self assert: aDateAndTime =  ((DateAndTime year: 2004 day: 60 hour: 13 minute: 33 second: 0) offset: 2 hours).
