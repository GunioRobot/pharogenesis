withdrawFromWorld
	"Close the socket, if any, and remove this hand from the world."

	self stopListening.
	Transcript show: 'Remote hand ', userInitials, ' closed'; cr.
	owner ifNotNil: [owner removeHand: self].
