justDroppedInto: aMorph event: anEvent
	"So that when the hand drops me (into the world) I go away"
	anEvent hand keyboardFocus == self
		ifTrue:[anEvent hand newKeyboardFocus: nil].
	self changed.
	self delete.
