cursorWrapped: aNumber
	"Set the cursor to the given number, modulo the number of items I contain. Fractional cursor values are allowed."
	| nextFrame |
	nextFrame _ aNumber truncated abs.
	nextFrame >= self maxFrames
		ifTrue: [nextFrame _ 1].
	self stepToFrame: nextFrame