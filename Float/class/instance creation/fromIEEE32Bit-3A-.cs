fromIEEE32Bit: word
	"Convert the given 32 bit word (which is supposed to be a positive 32bit value) from a 32bit IEEE floating point representation into an actual Squeak float object (being 64bit wide). Should only be used for conversion in FloatArrays or likewise objects."
	| sign mantissa exponent newFloat |
	word negative ifTrue: [^ self error:'Cannot deal with negative numbers'].
	word = 0 ifTrue:[^ 0.0].
	mantissa _ word bitAnd:  16r7FFFFF.
	exponent _ ((word bitShift: -23) bitAnd: 16rFF) - 127.
	sign _ word bitAnd: 16r80000000.

	exponent = 128 ifTrue:["Either NAN or INF"
		mantissa = 0 ifFalse:[^ Float nan].
		sign = 0 
			ifTrue:[^ Float infinity]
			ifFalse:[^ Float infinity negated]].

	"Create new float"
	newFloat _ self new: 2.
	newFloat basicAt: 1 put: ((sign bitOr: (1023 + exponent bitShift: 20)) bitOr: (mantissa bitShift: -3)).
	newFloat basicAt: 2 put: ((mantissa bitAnd: 7) bitShift: 29).
	^newFloat