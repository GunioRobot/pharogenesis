getReactionsTo: eventType
	"Return this actor's reactions to the given event type.  Because only first class actors react to mouse events, if this actor is a part pass this message up to its parent object."

	(self isFirstClass)
		ifTrue: [ (myReactions includesKey: eventType)
					ifTrue: [^ myReactions at: eventType ]
					ifFalse: [ ^ nil ].
				]
		ifFalse: [ ^ myParent getReactionsTo: eventType ].
