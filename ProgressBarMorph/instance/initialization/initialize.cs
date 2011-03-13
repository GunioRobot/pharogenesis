initialize
	super initialize.
	progressColor _ Color green.
	self value: (ValueHolder new contents: 0.0).
	lastValue _ 0.0