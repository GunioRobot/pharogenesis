mouseMove: evt
	oldPoint ifNil: [^super mouseMove: evt].
	(evt redButtonPressed) ifTrue: [
		(evt shiftPressed)
			ifTrue: [self panBy: oldPoint - evt cursorPoint]
			ifFalse: [
				(oldPoint = evt cursorPoint) ifFalse: [
					(self rotateFrom: oldPoint to: evt cursorPoint)]].
		oldPoint := evt cursorPoint].