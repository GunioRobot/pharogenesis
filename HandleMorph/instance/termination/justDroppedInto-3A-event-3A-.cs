justDroppedInto: aMorph event: anEvent
	"So that when the hand drops me (into the world) I go away"
	lastPointBlock ifNotNil: [lastPointBlock value: self center].
	self flag: #arNote. "Probably unnecessary"
	anEvent hand releaseKeyboardFocus: self.
	self changed.
	self delete.
