asFloat
	"Answer a Float that represents the value of the receiver.
	This is the nearest possible Float according to IEEE 754 round to nearest even mode.
	If the receiver is too large, then answer with Float infinity."
	
	| mantissa shift sum numberOfTruncatedBits mask truncatedBits |
	self isZero
		ifTrue: [^ 0.0].
	mantissa := self abs.

	"Assume Float is a double precision IEEE 754 number with 53bits mantissa.
	We should better use some Float class message for that (Float precision)..."
	numberOfTruncatedBits := mantissa highBit - 53.
	numberOfTruncatedBits > 0
		ifTrue: [mask := (1 bitShift: numberOfTruncatedBits) - 1.
			truncatedBits := mantissa bitAnd: mask.
			mantissa := mantissa bitShift: numberOfTruncatedBits negated.
			"inexact := truncatedBits isZero not."
			truncatedBits highBit = numberOfTruncatedBits
				ifTrue: ["There is a carry, whe must eventually round upper"
					(mantissa even and: [truncatedBits isPowerOfTwo])
						ifFalse: ["Either the mantissa is odd, and we must round upper to the nearest even
							Or the truncated part is not a power of two, so has more than 1 bit, so is > 0.5ulp: we must round upper"
							mantissa := mantissa + 1]]]
		ifFalse: [numberOfTruncatedBits := 0].
	
	"now, mantissa has no more than 53 bits, we can do exact floating point arithmetic"
	sum := 0.0.
	shift := numberOfTruncatedBits.
	1 to: mantissa digitLength do:
		[:byteIndex | 
		sum := ((mantissa digitAt: byteIndex) asFloat timesTwoPower: shift) + sum.
		shift := shift + 8].
	^ self positive
			ifTrue: [sum]
			ifFalse: [sum negated]

	
	"Implementation notes:
	The receiver is split in three parts:
	- a sign
	- a truncated mantissa made of first 53 bits which is the maximum precision of Float
	- trailing truncatedBits
	This is like placing a floating point after numberOfTruncatedBits from the right:
	self = (self sign*(mantissa + fractionPart)*(1 bitShift: numberOfTruncatedBits)).
	where 0 <= fractionPart < 1,
	fractionPart = (truncatedBits/(1 bitShift: numberOfTruncatedBits)).
	Note that the converson is inexact if fractionPart > 0.
	
	If fractionPart > 0.5 (2r0.1), then the mantissa must be rounded upward.
	If fractionPart = 0.5, then it is case of exact difference between two consecutive integers.
	In this later case, we always round to nearest even. That is round upward if mantissa is odd.

	The two cases imply first bit after floating point is 1: truncatedBits highBit = numberOfTruncatedBits
	Possible variants: (self abs bitAt: numberOfTruncatedBits) = 1
	In the former case, there must be another truncated bit set to 1: truncatedBits isPowerOfTwo not.
	Possible variants: (self abs lowBit < numberOfTruncatedBits)
	The later case is recognized as: mantissa odd.
	
	examples (I omit first 52 bits of mantissa for clarity)
	2r0.00001 is rounded to 2r0
	2r1.00001 is rounded to 2r1
	2r0.1 is rounded to 2r0 (nearest even)
	2r1.1 is rounded to 2r10 (nearest even)
	2r0.10001 is rounded to 2r1
	2r1.10001 is rounded to 2r10"