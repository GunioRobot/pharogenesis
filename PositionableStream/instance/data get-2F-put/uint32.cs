uint32
	"Answer the next unsigned, 32-bit integer from this (binary) stream."

	| n |
	n _ self next.
	n _ (n bitShift: 8) + self next.
	n _ (n bitShift: 8) + self next.
	n _ (n bitShift: 8) + self next.
	^ n
