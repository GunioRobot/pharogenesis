indicateColorUnderMouse
	"Track the mouse with the special eyedropper cursor, and accept whatever color is under the mouse as the currently-chosen color; reflect that choice in the feedback box, and return that color."

	| pt feedbackColor |
	pt _ Sensor cursorPoint.
	"deal with the fact that 32 bit displays may have garbage in the alpha bits"
	feedbackColor _ Display depth = 32
		ifTrue: [ Color colorFromPixelValue: ((Display pixelValueAt: pt) bitOr: 16rFF000000) depth: 32] 		ifFalse: [Display colorAt: pt].

	self activeHand position: pt.
	self world displayWorldSafely.
	Display fill: colorPatch bounds fillColor: feedbackColor.
	^ feedbackColor	