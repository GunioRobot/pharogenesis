asFloat
	"Answer a Float that represents the value of the receiver. Optimized to process only the significant digits of a LargeInteger."

	| sum factor numBytes |
	sum _ 0.0.
	factor _ self sign asFloat.
	numBytes _ self size.
	numBytes > 7
		ifFalse: [
			1 to: self size do: [:i |
				sum _ sum + ((self digitAt: i) * factor).
				factor _ factor * 256.0]]
		ifTrue: [
			(numBytes - 6) to: numBytes do: [:i |
				sum _ sum + ((self digitAt: i) * factor).
				factor _ factor * 256.0].
			sum _ sum timesTwoPower: 8 * (numBytes - 7)].
	^ sum