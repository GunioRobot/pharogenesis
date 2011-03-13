abs: aNumber1 arg: aNumber2
	| real imaginary |
	real := aNumber1 * aNumber2 cos.
	imaginary := aNumber1 * aNumber2 sin.
	^ real + imaginary i