mouseDown: evt
	"Start a new stroke.  Check if any palette setting have changed.  6/11/97 20:30 tk"
	| cur pfPen myAction |
	"verify that we are in a good state"
	self verifyState: evt.		"includes prepareToPaint and #scalingOrRotate"
	pfPen _ self get: #paintingFormPen for: evt.
	undoBuffer _ paintingForm deepCopy.	"know we will draw something"
	pfPen place: (evt cursorPoint - bounds origin).
	myAction _ self getActionFor: evt.
	myAction == #paint: ifTrue:[
		palette recentColor: (self getColorFor: evt)].
	self set: #strokeOrigin for: evt to: evt cursorPoint.
		"origin point for pickup: rect: ellispe: polygon: line: star:.  Always take it."
	myAction == #pickup: ifTrue: [
		cur _ Cursor corner clone.
		cur offset: 0@0  "cur offset abs".
		evt hand showTemporaryCursor: cur].
	myAction == #polygon: ifTrue: [self polyNew: evt].	"a mode lets you drag vertices"
	self mouseMove: evt.