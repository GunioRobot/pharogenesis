initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self beSmoothCurve.
	vertices _ {11 @ 3. 35 @ 1. 60 @ 5. 67 @ 17. 34 @ 24. 3 @ 17}.
	
	closed _ true.
	self neutral; updateShape