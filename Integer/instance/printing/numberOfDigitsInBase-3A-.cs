numberOfDigitsInBase: b 
	"Return how many digits are necessary to print this number in base b.
	This does not count any place for minus sign, radix prefix or whatever.
	Note that this algorithm may cost a few operations on LargeInteger."

	| nDigits q |
	self negative ifTrue: [^self negated numberOfDigitsInBase: b].
	self < b ifTrue: [^1].
	b isPowerOfTwo	ifTrue: [^self highBit + b highBit - 2 quo: b highBit - 1].
	
	"A conversion from base 2 to base b has to be performed.
	This algorithm avoids Float computations like (self log: b) floor + 1,
	1) because they are inexact
	2) because LargeInteger might overflow
	3) because this algorithm might be cheaper than conversion"

	"Make an initial nDigits guess that is lower than or equal to required number of digits"
	b = 10
		ifTrue: [nDigits := ((self highBit - 1) * 3 quo: 10) + 1. "This is because 1024 is a little more than a kilo"]
		ifFalse: [nDigits := self highBit quo: b highBit].

	"See how many digits remains above these first nDigits guess"
	q := self quo: (b raisedTo: nDigits).
	^q = 0
		ifTrue: [nDigits]
		ifFalse: [nDigits + (q numberOfDigitsInBase: b)]