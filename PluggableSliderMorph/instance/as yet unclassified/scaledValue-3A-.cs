scaledValue: newValue
	"Set the scaled value."

	|val|
	val := newValue.
	self quantum ifNotNilDo: [:q |
		val := val roundTo: q].
	self value: newValue - self min / (self max - self min)