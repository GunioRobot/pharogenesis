peekEvent
	"Look ahead at the next event."
	eventQueue ifNil:[^nil].
	self fetchMoreEvents.
	^eventQueue peek