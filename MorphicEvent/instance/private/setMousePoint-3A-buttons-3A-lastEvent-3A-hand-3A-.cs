setMousePoint: aPoint buttons: anInteger lastEvent: lastEvent hand: hand

	cursorPoint _ aPoint.
	buttons _ anInteger.
	keyValue _ 0.
	sourceHand _ hand.

	self anyButtonPressed ifTrue: [
		lastEvent anyButtonPressed
			ifTrue: [type _ #mouseMove]
			ifFalse: [type _ #mouseDown].
	] ifFalse: [
		lastEvent anyButtonPressed
			ifTrue: [type _ #mouseUp]
			ifFalse: [type _ #mouseMove]].

