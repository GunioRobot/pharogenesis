reverseBits: code length: length
	"Bit reverse the given code"
	| result bit bits |
	result _ 0.
	bits _ code.
	1 to: length do:[:i|
		bit _ bits bitAnd: 1.
		result _ result << 1 bitOr: bit.
		bits _ bits >> 1].
	^result