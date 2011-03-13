asFloat
	"Answer a Float that closely approximates the value of the receiver.
	Ideally, answer the Float that most closely approximates the receiver."

	| nScaleBits dScaleBits nScaled dScaled |

	"Scale the numerator by throwing away all but the
	top 8 digits (57 to 64 significant bits) then making that a Float.
	This keeps all of the precision of a Float (53 significand bits) but
	guarantees that we do not exceed the range representable as a Float
	(about 2 to the 1024th)"

	nScaleBits _ 8 * ((numerator digitLength - 8) max: 0).
	nScaled _ (numerator bitShift: nScaleBits negated) asFloat.

	"Scale the denominator the same way."
	dScaleBits _ 8 * ((denominator digitLength - 8) max: 0).
	dScaled _ (denominator bitShift: dScaleBits negated) asFloat.

	"Divide the scaled numerator and denominator to make the 
right mantissa, then scale to correct the exponent."
	^ (nScaled / dScaled) timesTwoPower: (nScaleBits - dScaleBits).