predecessor
	| mantissa biasedExponent |
	self isFinite ifFalse: [
		(self isNaN or: [self negative]) ifTrue: [^self].
		^Float fmax].
	self = 0.0 ifTrue: [^Float fmin negated].
	mantissa := self significandAsInteger.
	(mantissa isPowerOfTwo and: [self positive]) ifTrue: [mantissa := mantissa bitShift: 1].
	biasedExponent := self exponent - mantissa highBit + 1.
	^self sign * (mantissa - self sign) asFloat timesTwoPower: biasedExponent