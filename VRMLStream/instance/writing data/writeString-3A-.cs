writeString: aString
	self nextPut:$".
	aString do:[:char|
		char = $" ifTrue:[self nextPut:$\].
		char = $\ ifTrue:[self nextPut:$\].
		self nextPut: char.
	].
	self nextPut:$".
