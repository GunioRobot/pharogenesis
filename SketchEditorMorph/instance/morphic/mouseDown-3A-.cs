mouseDown: evt
	"Start a new stroke.  Check if any palette setting have changed.  6/11/97 20:30 tk"
	| cur |
	"verify that we are in a good state"
	self verifyState.		"includes prepareToPaint and #scalingOrRotate"
	undoBuffer _ paintingForm deepCopy.	"know we will draw something"
	paintingFormPen place: (evt cursorPoint - bounds origin).
	strokeOrigin _ evt cursorPoint.
		"origin point for pickup: rect: ellispe: polygon: line: star:.  Always take it."
	action == #pickup: ifTrue: [
		cur _ Cursor corner clone.
		cur offset: 0@0  "cur offset abs".
		evt hand showTemporaryCursor: cur].
	action == #polygon: ifTrue: [self polyNew: evt].	"a mode lets you drag vertices"
