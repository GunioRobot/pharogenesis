testPlusDays
	self assert: (aTimeStamp plusDays: 366) dateAndTime
			= (Array with: '01-02-2005' asDate with: '00:34:56' asTime)