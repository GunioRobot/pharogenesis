addResponse: aReaction to: evtType
	"Add a new response to the given event type"

	| newReaction currentReactions |

	(myReactions includesKey: evtType)
		ifFalse: [ myReactions at: evtType put: OrderedCollection new ].

	currentReactions _ myReactions at: evtType.

	newReaction _ WonderlandReaction new: aReaction.

	currentReactions addLast: newReaction.

	^ newReaction.
