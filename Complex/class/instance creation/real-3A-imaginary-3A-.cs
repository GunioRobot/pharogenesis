real: aNumber1 imaginary: aNumber2
	| newComplex |
	newComplex _ super new.
	newComplex
		real: aNumber1;
		imaginary: aNumber2.
	^ newComplex