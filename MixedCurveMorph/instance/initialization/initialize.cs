initialize
"initialize the state of the receiver"
	super initialize.
	self extent: 32@20 .

	self rectOval.
	self clamps . "This initializes slopeClamps."
	slopeClamps at: 1 put: 0 .
	slopeClamps at: 4 put: 0 .
	
	closed _ true.
	smoothCurve _ true.
	arrows _ #none.
	self computeBounds