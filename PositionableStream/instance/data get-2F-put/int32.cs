int32
	"Answer the next signed, 32-bit integer from this (binary) stream."
	"Details: As a fast check for negative number, check the high bit of the first digit"

	| n firstDigit |
	n _ firstDigit _ self next.
	n _ (n bitShift: 8) + self next.
	n _ (n bitShift: 8) + self next.
	n _ (n bitShift: 8) + self next.
	firstDigit >= 128 ifTrue: [n _ -16r100000000 + n].  "decode negative 32-bit integer"
	^ n
