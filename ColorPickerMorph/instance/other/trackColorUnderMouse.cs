trackColorUnderMouse
	"Track the mouse with the special eyedropper cursor, and accept whatever color is under the mouse as the currently-chosen color; reflect that choice in the feedback box, and return that color."

	| pt |
	selectedColor _ originalColor.
	self trackColorAt: (pt _ Sensor cursorPoint).
	isModal ifTrue:
		[self activeHand position: pt.
		self world displayWorldSafely; runStepMethods.
		self modalBalloonHelpAtPoint: pt].
	^ selectedColor	