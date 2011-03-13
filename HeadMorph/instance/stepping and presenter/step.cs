step
	| now |
	super step.
	now := Time millisecondClockValue.
	[queue isEmpty not and: [now >= queue peek key]]
		whileTrue: [queue next value actOn: self].
	self face lips updateShape