checkIfTimeToDisplay

	remote backlog > 0 ifTrue: [^self].	"why bother if network full?"
	dirtyRect ifNil: [^self].
	self sendDeltas.
	lastTick _ Time millisecondClockValue.

