addLast: newObject 
	"Add newObject to the end of the receiver. Answer newObject."

	lastIndex = array size ifTrue: [self makeRoomAtLast].
	lastIndex _ lastIndex + 1.
	array at: lastIndex put: newObject.
	^ newObject