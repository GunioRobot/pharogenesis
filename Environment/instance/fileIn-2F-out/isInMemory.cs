isInMemory
	self associationsDo:
		[:a | ^ a value isInMemory].
	^ true