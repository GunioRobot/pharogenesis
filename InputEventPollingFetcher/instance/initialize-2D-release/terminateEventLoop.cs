terminateEventLoop
	"Terminate the event loop process. Terminate the old process if any."
	"InputEventFetcher default terminateEventLoop"

	super terminateEventLoop.
	self class resetEventPollDelay