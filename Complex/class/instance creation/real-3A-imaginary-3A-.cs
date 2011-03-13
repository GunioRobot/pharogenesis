real: aNumber1 imaginary: aNumber2
	| newComplex |
	newComplex := super new.
	newComplex
		real: aNumber1;
		imaginary: aNumber2.
	^ newComplex