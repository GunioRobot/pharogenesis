initialize
	super initialize.
	lastCursorPoint _ 0 @ 0.
	CurrentProjectRefactoring currentAddGuard: self.

	"Teddy"
	self mode: nil.
	self outline: nil.