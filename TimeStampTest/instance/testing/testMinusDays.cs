testMinusDays
	self assert: (aTimeStamp minusDays: 5) dateAndTime
			= (Array with: '12-28-2003' asDate with: '00:34:56' asTime)