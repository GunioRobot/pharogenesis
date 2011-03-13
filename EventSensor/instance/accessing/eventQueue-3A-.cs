eventQueue: aSharedQueue
	"Install a new queue for events.
	If an eventQueue is present all events will be queued up there.
	It is assumed that a client installing an event queue will actually
	read data from it, otherwise the system will overflow."
	eventQueue _ aSharedQueue.