testPlusSecondsOverMidnight
	self assert: (aTimeStamp plusSeconds: 24 * 60 * 60 + 1) dateAndTime
			= (Array with: '01-03-2004' asDate with: '00:34:57' asTime)