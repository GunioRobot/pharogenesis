myEvents
	"Private. Answer a Dictionary with the receiver's events or nil if no
	events have been registered. Subclasses may overwrite this method
	for performance reasons."

	^ EventsFields at: self ifAbsent: []