primitiveShowDisplayRect
	"Force the given rectangular section of the Display to be 
	copied to the screen."
	| bottom top right left |
	bottom _ self stackIntegerValue: 0.
	top _ self stackIntegerValue: 1.
	right _ self stackIntegerValue: 2.
	left _ self stackIntegerValue: 3.
	self displayBitsOf: (self splObj: TheDisplay) Left: left Top: top Right: right Bottom: bottom.
	successFlag
		ifTrue: [self ioForceDisplayUpdate.
			self pop: 4]