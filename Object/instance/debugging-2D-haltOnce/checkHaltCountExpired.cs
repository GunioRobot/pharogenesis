checkHaltCountExpired
	| counter |
	counter _ Smalltalk at: #HaltCount ifAbsent: [0].
	^counter = 0