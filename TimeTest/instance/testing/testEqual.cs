testEqual
	self assert: aTime = (Time readFrom: (ReadStream on: '12:34:56')).