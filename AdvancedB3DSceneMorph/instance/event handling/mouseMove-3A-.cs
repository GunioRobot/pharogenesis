mouseMove: evt
	oldPoint ifNil: [^super mouseMove: evt].
	((evt redButtonPressed) and: [evt shiftPressed]) ifTrue: [
		self panBy: oldPoint - evt cursorPoint.
		oldPoint := evt cursorPoint.]