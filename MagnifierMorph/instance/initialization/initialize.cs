initialize
	"initialize the state of the receiver"
	super initialize.

	trackPointer _ true.
	showPointer _ false.
	magnification _ 2.

	self extent: 128 @ 128