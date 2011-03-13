successor
	| mantissa biasedExponent |
	self isFinite ifFalse: [
		(self isNaN or: [self positive]) ifTrue: [^self].
		^Float fmax negated].
	self = 0.0 ifTrue: [^Float fmin].
	mantissa := self significandAsInteger.
	(mantissa isPowerOfTwo and: [self negative]) ifTrue: [mantissa := mantissa bitShift: 1].
	biasedExponent := self exponent - mantissa highBit + 1.
	^self sign * (mantissa + self sign) asFloat timesTwoPower: biasedExponent