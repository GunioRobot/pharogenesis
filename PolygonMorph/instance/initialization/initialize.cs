initialize
"initialize the state of the receiver"
	super initialize.
""
	vertices _ Array
				with: 5 @ 0
				with: 20 @ 10
				with: 0 @ 20.
	closed _ true.
	smoothCurve _ false.
	arrows _ #none.
	self computeBounds