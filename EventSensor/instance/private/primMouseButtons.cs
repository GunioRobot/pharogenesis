primMouseButtons
	self wait2ms.
	self fetchMoreEvents.
	self flushNonKbdEvents.
	^ mouseButtons