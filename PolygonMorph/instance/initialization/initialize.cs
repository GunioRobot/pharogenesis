initialize
	super initialize.
	vertices _ Array with: 20@20 with: 40@30 with: 20@40.
	borderWidth _ 2.
	borderColor _ Color magenta.
	closed _ true.
	quickFill _ true.
	arrows _ #none.
	self computeBounds.
