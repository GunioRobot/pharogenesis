step
	| now |
	super step.
	now _ Time millisecondClockValue.
	[queue isEmpty not and: [now >= queue peek key]]
		whileTrue: [queue next value actOn: self].
	self face lips updateShape