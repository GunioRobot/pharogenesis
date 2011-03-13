collect: aBlock
	| nextValue result |
	result _ self species new: self size.
	nextValue _ start.
	1 to: result size do:
		[:i |
		result at: i put: (aBlock value: nextValue).
		nextValue _ nextValue + step].
	^ result