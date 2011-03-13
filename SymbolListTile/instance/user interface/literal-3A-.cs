literal: anObject
	"Set the receiver's literal as indicated"

	literal _ anObject.
	self updateLiteralLabel.
	self labelMorph informTarget