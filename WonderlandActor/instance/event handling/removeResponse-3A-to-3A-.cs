removeResponse: aReaction to: evtType
	"Remove the response to the given event type"

	(myReactions includesKey: evtType)
		ifTrue: [ (myReactions at: evtType) remove: aReaction ].
