testSubtractTime
	self assert: (aTime subtractTime: aTime) = (Time readFrom: (ReadStream on: '00:00:00'))
