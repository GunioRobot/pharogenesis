testPlusSeconds
	self assert: (aTimeStamp plusSeconds: 60 * 60 ) dateAndTime
			= (Array with: '01-02-2004' asDate with: '01:34:56' asTime)