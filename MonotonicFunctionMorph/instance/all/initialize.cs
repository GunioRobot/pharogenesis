initialize
	super initialize.
	borderWidth _ 2.
	borderColor _ Color green darker.
	closed _ false.
	quickFill _ true.
	arrows _ #none.
	self setVertices: (Array with: 20@40 with: 40@30 with: 60@40).
