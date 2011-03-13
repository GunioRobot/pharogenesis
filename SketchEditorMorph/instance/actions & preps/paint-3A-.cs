paint: evt
	"While the mouse is down, lay down paint, but only within window bounds.
	 11/28/96 sw: no longer stop painting when pen strays out of window; once it comes back in, resume painting rather than waiting for a mouse up"

	|  mousePoint startRect endRect startToEnd pfPen myBrush |

	pfPen _ self get: #paintingFormPen for: evt.
	myBrush _ self getBrushFor: evt.
	mousePoint _ evt cursorPoint.
	startRect _ pfPen location + myBrush offset extent: myBrush extent.
	pfPen goto: mousePoint - bounds origin.
	endRect _ pfPen location + myBrush offset extent: myBrush extent.
	"self render: (startRect merge: endRect).	Show the user what happened"
	startToEnd _ startRect merge: endRect.
	self invalidRect: (startToEnd translateBy: bounds origin).
