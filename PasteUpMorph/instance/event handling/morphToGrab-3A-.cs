morphToGrab: event
	"Return the morph to grab from a mouse down event. If none, return nil."
	self submorphsDo:[:m|
		(m isLocked not and:[m fullContainsPoint: event cursorPoint]) ifTrue:[^m].
	].
	^nil