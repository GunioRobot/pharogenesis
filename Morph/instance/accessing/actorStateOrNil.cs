actorStateOrNil
	"answer the redeiver's actorState"
	^ self hasExtension
		ifTrue: [self extension actorState]