testAddTime
	self assert: (aTime addTime: aTime) = (Time readFrom: (ReadStream on: '01:09:52')).
