printStringOf: oop

	| fmt cnt i |
	fmt _ self formatOf: oop.
	fmt < 8 ifTrue: [ ^nil ].

	cnt _ 100 min: (self lengthOf: oop).
	i _ 0.
	[i < cnt] whileTrue: [
		self printChar: (self fetchByte: i ofObject: oop).
		i _ i + 1.
	].