startReportingEventsTo: subscriber
	"Start reporting events to the given object. All input events are reported to every event subscriber, in addition to being sent to the current mouse/keyboard focus morph. This allows one to build things like macro recorders, eyes that follow the mouse, etc."

	(eventSubscribers includes: subscriber) ifFalse: [eventSubscribers add: subscriber].