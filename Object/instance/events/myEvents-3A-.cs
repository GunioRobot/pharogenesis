myEvents: aDictionaryOrNil
	"Private. Set (or remove) the receiver's dictionary of events.
	Subclasses may overwrite this method for performance reasons."

	aDictionaryOrNil
		ifNil: [EventsFields removeKey: self ifAbsent: []]
		ifNotNil: [EventsFields at: self put: aDictionaryOrNil]