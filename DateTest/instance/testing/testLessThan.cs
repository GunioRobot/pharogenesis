testLessThan
	self assert: aDate < (Date readFrom: (ReadStream on: '01-24-2004')).