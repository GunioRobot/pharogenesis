bitsSize
	| pixPerWord |
	depth == nil ifTrue: [depth _ 1].
	pixPerWord _ 32 // self depth.
	^ width + pixPerWord - 1 // pixPerWord * height