primitiveSecondsClock
	"Return the number of seconds since January 1, 1901 as an integer."

	self pop: 1.  "pop rcvr"
	self push: (self positive32BitIntegerFor: self ioSeconds).