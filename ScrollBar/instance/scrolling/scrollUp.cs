scrollUp
	(self waitForDelay1: 300 delay2: 50) ifFalse: [^ self].
	self setValue: (value - scrollDelta - 0.000001 max: 0.0)