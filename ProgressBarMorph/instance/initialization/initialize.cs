initialize
	super initialize.
	progressColor := Color green.
	self value: (ValueHolder new contents: 0.0).
	lastValue := 0.0