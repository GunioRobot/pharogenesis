asTrueFraction
	" Answer a fraction that EXACTLY represents self,
	  a double precision IEEE floating point number.
	  (It tears an IEEE float into its components; it
	  assumes 'correct' byte ordering; runs on PPC.) 
	  Thanks to David N. Smith"
	| shifty sign exp fraction |
	shifty := ((self at: 1) bitShift: 32) bitOr: (self at: 2).
	sign := (shifty bitShift: -63) = 0 ifTrue: [1] ifFalse: [-1].
	exp := (shifty >> 52) bitAnd: 16r7FF.
	fraction := shifty bitAnd:  16r000FFFFFFFFFFFFF.
	(exp = 0) & (fraction = 0) ifTrue: [ ^ 0  ].
	fraction := fraction bitOr: 16r0010000000000000.
	exp := exp - 16r3FF.
	" Validate that the dismemberment was correct "
	(sign * fraction / (2 raisedToInteger: 52 - exp)) asFloat = self
		ifFalse: [self error: 'asFraction validation failed' ].
	^ sign * fraction / (2 raisedToInteger: 52 - exp)