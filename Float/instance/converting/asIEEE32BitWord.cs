asIEEE32BitWord
	"Convert the receiver into a 32 bit Integer value representing the same number in IEEE 32 bit format. Used for conversion in FloatArrays only."
	| word1 word2 sign mantissa exponent destWord |
	self = 0.0 ifTrue:[^0].
	word1 _ self basicAt: 1.
	word2 _ self basicAt: 2.
	mantissa _ (word2 bitShift: -29) + ((word1 bitAnd:  16rFFFFF) bitShift: 3).
	exponent _ ((word1 bitShift: -20) bitAnd: 16r7FF) - 1023 + 127.
	exponent < 0 ifTrue:[^0]. "Underflow"
	exponent > 254 ifTrue:["Overflow"
		exponent _ 255.
		mantissa _ 0].
	sign _ word1 bitAnd: 16r80000000.
	destWord _ (sign bitOr: (exponent bitShift: 23)) bitOr: mantissa.
	^ destWord