initialize
	super initialize.
	lastCursorPoint _ 0 @ 0.
	Project current addGuard: self.

	"Teddy"
	self mode: #view.
	self outline: POSimplePolygon new