respondWith: aReaction to: evtType
	"Set this actor's response to the given event type"

	| reaction collection |

	aReaction ifNil: [ myReactions removeKey: evtType ifAbsent: [].
					  ^ nil ].

	reaction _ WonderlandReaction new: aReaction.

	collection _ OrderedCollection new.
	collection addLast: reaction.

	myReactions at: evtType put: collection.

	^ reaction.
