asTrueFraction
	" Answer a fraction that EXACTLY represents self,
	  a double precision IEEE floating point number.
	  Floats are stored in the same form on all platforms.
	  (Does not handle gradual underflow or NANs.)
	  By David N. Smith with significant performance
	  improvements by Luciano Esteban Notarfrancesco.
	  (Version of 11April97)"
	| shifty sign expPart exp fraction fractionPart result zeroBitsCount |
	self isInfinite ifTrue: [self error: 'Cannot represent infinity as a fraction'].
	self isNaN ifTrue: [self error: 'Cannot represent Not-a-Number as a fraction'].

	" Extract the bits of an IEEE double float "
	shifty := ((self basicAt: 1) bitShift: 32) + (self basicAt: 2).

	" Extract the sign and the biased exponent "
	sign := (shifty bitShift: -63) = 0 ifTrue: [1] ifFalse: [-1].
	expPart := (shifty bitShift: -52) bitAnd: 16r7FF.

	" Extract fractional part; answer 0 if this is a true 0.0 value "
	fractionPart := shifty bitAnd:  16r000FFFFFFFFFFFFF.
	( expPart=0 and: [ fractionPart=0 ] ) ifTrue: [ ^ 0  ].

	" Replace omitted leading 1 in fraction "
	fraction := fractionPart bitOr: 16r0010000000000000.

	"Unbias exponent: 16r3FF is bias; 52 is fraction width"
	exp := 16r3FF + 52 - expPart.

	" Form the result. When exp>52, the exponent is adjusted by
	  the number of trailing zero bits in the fraction to minimize
	  the (huge) time otherwise spent in #gcd:. "
	exp negative
		ifTrue: [
			result := sign * fraction bitShift: exp negated ]
		ifFalse:	[
			zeroBitsCount _ fraction lowBit - 1.
			exp := exp - zeroBitsCount.
			exp <= 0
				ifTrue: [
					zeroBitsCount := zeroBitsCount + exp.
					"exp := 0."   " Not needed; exp not
refernced again "
					result := sign * fraction bitShift:
zeroBitsCount negated ]
				ifFalse: [
					result := Fraction
						numerator: (sign * fraction
bitShift: zeroBitsCount negated)
						denominator: (1 bitShift:
exp) ] ].

	" Validate the result (low cost; optional); answer result "
	(result asFloat = self)
		ifFalse: [self error: 'asTrueFraction validation failed' ].
	^ result 