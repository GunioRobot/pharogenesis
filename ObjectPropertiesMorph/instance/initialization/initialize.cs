initialize
"initialize the state of the receiver"
	super initialize.
""
	myTarget
		ifNil: [myTarget _ RectangleMorph new openInWorld].
	self rebuild