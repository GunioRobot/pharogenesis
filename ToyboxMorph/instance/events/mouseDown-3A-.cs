mouseDown: evt
	"Grab or copy the front-mouse submorph at the point where the mouse went down."

	| morphToGrab |
	submorphs do: [:m |
		(m fullContainsPoint: evt cursorPoint) ifTrue: [
			(locked and: [copyWhenLocked])
				ifTrue: [morphToGrab _ m fullCopy]
				ifFalse: [morphToGrab _ m].
			evt hand grabMorph: morphToGrab.
			^ self]].
	evt hand grabMorph: self.
