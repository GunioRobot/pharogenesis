getScaledValue
	| aValue |
	aValue _ (value * (maxVal - minVal)) + minVal.
	^ truncate ifTrue: [aValue truncated] ifFalse: [aValue]