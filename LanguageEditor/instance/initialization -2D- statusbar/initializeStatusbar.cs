initializeStatusbar
	"initialize the receiver's statusbar"
	self
		addMorph: self createStatusbar
		frame: (0 @ 0.93 corner: 1 @ 1)