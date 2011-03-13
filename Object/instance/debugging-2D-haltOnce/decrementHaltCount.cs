decrementHaltCount
	| counter |
	counter := Smalltalk
				at: #HaltCount
				ifAbsent: [0].
	counter > 0 ifTrue: [
		counter _ counter - 1.
		self setHaltCountTo: counter]