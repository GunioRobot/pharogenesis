testDateAndTime
	self assert: aTimeStamp dateAndTime
			= (Array with: '01-02-2004' asDate with: '00:34:56' asTime)