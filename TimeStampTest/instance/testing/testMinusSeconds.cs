testMinusSeconds
	self assert: (aTimeStamp minusSeconds: 34 * 60 + 56) dateAndTime
			= (Array with: '01-02-2004' asDate with: '00:00:00' asTime)