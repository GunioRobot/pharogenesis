asFloat
	"Answer a Float that represents the value of the receiver.
	Optimized to process only the significant digits of a LargeInteger.
	SqR: 11/30/1998 21:11"

	| sum firstByte shift |
	shift _ 0.
	sum _ 0.0.
	firstByte _ self size - 7 max: 1.
	firstByte to: self size do:
		[:byteIndex | 
		sum _ ((self digitAt: byteIndex) asFloat timesTwoPower: shift) + sum.
		shift _ shift + 8].
	^sum * self sign asFloat timesTwoPower: firstByte - 1 * 8