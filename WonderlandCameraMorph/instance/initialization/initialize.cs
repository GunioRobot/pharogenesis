initialize
	super initialize.
	lastCursorPoint _ 0 @ 0.
	CurrentProjectRefactoring currentAddGuard: self.

	"Teddy"
	self mode: #view.
	self outline: POSimplePolygon new