at: key
	self touch.
	^data at: key ifAbsent: [self error: 'Internal key error. Please alert administrator about key',key printString].
