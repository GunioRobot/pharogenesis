peekEvent
	"Look ahead at the next event."
	self fetchMoreEvents.
	^self eventQueue peek