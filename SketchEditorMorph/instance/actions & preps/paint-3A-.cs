paint: evt
	"While the mouse is down, lay down paint, but only within window bounds.
	 11/28/96 sw: no longer stop painting when pen strays out of window; once it comes back in, resume painting rather than waiting for a mouse up"

	|  mousePoint startRect endRect |

	mousePoint _ evt cursorPoint.
	startRect _ paintingFormPen location + brush offset extent: brush extent.
	paintingFormPen goto: mousePoint - bounds origin.
	endRect _ paintingFormPen location + brush offset extent: brush extent.
	"self render: (startRect merge: endRect).	Show the user what happened"
	self invalidRect: ((startRect merge: endRect) translateBy: bounds origin).
