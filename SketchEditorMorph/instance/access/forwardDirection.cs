forwardDirection
	"The direction object will go when issued a sent forward:.  Up is
zero.  Clockwise like a compass.  From the arrow control."

| bb |
bb _ (self valueOfProperty: #fwdButton).
^ (self center - bb vertices first) degrees - 90.0