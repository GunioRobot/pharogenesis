abort
	| oldRequests |
	"Abort all requests"
	oldRequests _ requests.
	requests _ SharedQueue new.
	[oldRequests isEmpty] whileFalse: [
		oldRequests next signalAbort].
	downloads do: [:each | each ifNotNil: [each terminate]].
	downloads _ OrderedCollection new
