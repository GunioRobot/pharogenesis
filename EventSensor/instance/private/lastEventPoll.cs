lastEventPoll
	"Answer the last clock value at which fetchMoreEvents was called."
	^lastEventPoll ifNil: [ lastEventPoll _ Time millisecondClockValue ]