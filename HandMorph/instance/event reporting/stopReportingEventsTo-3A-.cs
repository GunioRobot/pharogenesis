stopReportingEventsTo: subscriber
	"Stop reporting events to the given object."

	eventSubscribers remove: subscriber ifAbsent: [].