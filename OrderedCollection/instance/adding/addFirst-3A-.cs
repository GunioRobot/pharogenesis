addFirst: newObject 
	"Add newObject to the beginning of the receiver. Answer newObject."

	firstIndex = 1 ifTrue: [self makeRoomAtFirst].
	firstIndex _ firstIndex - 1.
	array at: firstIndex put: newObject.
	^ newObject