initialize
	"initialize the state of the receiver"
	super initialize.
	""
	growingOrRotating := false.
	simpleMode := Preferences simpleHalosInForce.
	self borderStyle: (SimpleBorder
		width: 2
		color: (Preferences menuSelectionColor ifNil: [Color blue]))