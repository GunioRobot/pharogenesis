testReadFrom
	self assert: aDuration =  (Duration readFrom: (ReadStream on: '1:02:03:04.000000005'))
