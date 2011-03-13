asFloat
	"Answer a Float that represents the value of the receiver.
	Optimized to process only the significant digits of a LargeInteger.
	SqR: 11/30/1998 21:1
	
	This algorithm does honour IEEE 754 round to nearest even mode.
	Numbers are first rounded on nearest integer on 53 bits.
	In case of exact half difference between two consecutive integers (2r0.1),
	there are two possible choices (two integers are as near, 0 and 1)
	In this case, the nearest even integer is chosen.
	examples (with less than 53bits for clarity)
	2r0.00001 is rounded to 2r0
	2r1.00001 is rounded to 2.1
	2r0.1 is rounded to 2r0 (nearest event)
	2r1.1 is rounded to 2.10 (neraest even)
	2r0.10001 is rounded to 2r1
	2r1.10001 is rounded to 2.10"
	
	| abs shift sum delta mask trailingBits carry |
	self isZero
		ifTrue: [^ 0.0].
	abs := self abs.

	"Assume Float is a double precision IEEE 754 number with 53bits mantissa.
	We should better use some Float class message for that (Float precision)..."
	delta := abs highBit - 53.
	delta > 0
		ifTrue: [mask := (1 bitShift: delta) - 1.
			trailingBits := abs bitAnd: mask.
			"inexact := trailingBits isZero not."
			carry := trailingBits bitShift: 1 - delta.
			abs := abs bitShift: delta negated.
			shift := delta.
			(carry isZero
					or: [(trailingBits bitAnd: (mask bitShift: -1)) isZero
							and: [abs even]])
				ifFalse: [abs := abs + 1]]
		ifFalse: [shift := 0].
	
	"now, abs has no more than 53 bits, we can do exact floating point arithmetic"
	sum := 0.0.
	1 to: abs size do:
		[:byteIndex | 
		sum := ((abs digitAt: byteIndex) asFloat timesTwoPower: shift) + sum.
		shift := shift + 8].
	^ self positive
			ifTrue: [sum]
			ifFalse: [sum negated]