int16
	"Answer the next signed, 16-bit integer from this (binary) stream."

	| n |
	n _ self next.
	n _ (n bitShift: 8) + (self next).
	n >= 16r8000 ifTrue: [n _ n - 16r10000].
	^ n
