offsetObjectOf: offsetValue
	"This method must be overridden in the simulator because the simulated
	object memory cannot store negative integers."

	self assertIsIntegerObject: (offsetValue + 1).
	^offsetValue + 1