clampAllFrom: minValue to: maxValue
	"Clamp all elements in the receiver to be in the range (minValue, maxValue)"
	| value |
	1 to: self basicSize do:[:i|
		value _ self floatAt: i.
		value _ value min: maxValue.
		value _ value max: minValue.
		self floatAt: i put: value.
	].