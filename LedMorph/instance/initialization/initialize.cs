initialize
"initialize the state of the receiver"
	super initialize.
""
	flashing _ false.
	flash _ false.
	self scrollInit.
	self digits: 2.
	self value: 0