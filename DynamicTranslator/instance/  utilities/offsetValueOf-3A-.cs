offsetValueOf: offsetObject
	"This method must be overridden in the simulator because the simulated
	object memory cannot store negative integers.  In the translated VM we win
	big from the compiler combining sequences of arithmetic operations on the
	localIP, the overall effect of which is that the transformation from an
	integer-encoded form to a usable offset has zero overhead in many cases."

	self assertIsIntegerObject: offsetObject.
	^offsetObject - 1