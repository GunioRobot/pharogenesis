abs: aNumber1 arg: aNumber2
	| real imaginary |
	real _ aNumber1 * aNumber2 cos.
	imaginary _ aNumber1 * aNumber2 sin.
	^ real + imaginary i