primMousePt
	self wait2ms.
	self fetchMoreEvents.
	self flushNonKbdEvents.
	^ mousePosition