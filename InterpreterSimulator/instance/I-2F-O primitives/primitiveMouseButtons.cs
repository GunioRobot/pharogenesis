primitiveMouseButtons
	| buttons |
	self pop: 1.
	buttons _ Sensor primMouseButtons.
	self pushInteger: buttons