nextStringPut: aString

	aString do:[:char| self nextBytePut: (self convertCharFromSqueak: char) asInteger].
	self nextBytePut: 0.