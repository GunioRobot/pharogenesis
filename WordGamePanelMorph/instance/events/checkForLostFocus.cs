checkForLostFocus
	"Determine if the user has clicked outside this panel"

	self activeHand ifNil: [^ self].
	(self containsPoint: self activeHand position) ifFalse: [self lostFocus]