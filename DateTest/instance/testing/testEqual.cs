testEqual
	self assert: aDate = (Date readFrom: (ReadStream on: 'January 23, 2004')).