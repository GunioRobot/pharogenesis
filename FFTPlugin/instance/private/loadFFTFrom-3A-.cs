loadFFTFrom: fftOop
	| oop |
	interpreterProxy success: (interpreterProxy slotSizeOf: fftOop) >= 6.
	interpreterProxy failed ifTrue:[^false].
	nu _ interpreterProxy fetchInteger: 0 ofObject: fftOop.
	fftSize _ interpreterProxy fetchInteger: 1 ofObject: fftOop.

	oop _ interpreterProxy fetchPointer: 2 ofObject: fftOop.
	sinTableSize _ interpreterProxy stSizeOf: oop.
	sinTable _ self checkedFloatPtrOf: oop.

	oop _ interpreterProxy fetchPointer: 3 ofObject: fftOop.
	permTableSize _ interpreterProxy stSizeOf: oop.
	permTable _ self checkedWordPtrOf: oop.

	oop _ interpreterProxy fetchPointer: 4 ofObject: fftOop.
	realDataSize _ interpreterProxy stSizeOf: oop.
	realData _ self checkedFloatPtrOf: oop.

	oop _ interpreterProxy fetchPointer: 5 ofObject: fftOop.
	imagDataSize _ interpreterProxy stSizeOf: oop.
	imagData _ self checkedFloatPtrOf: oop.

	"Check assumptions about sizes"
	interpreterProxy success:
		(1 << nu = fftSize) & 
		(fftSize // 4 + 1 = sinTableSize) & 
		(fftSize = realDataSize) & 
		(fftSize = imagDataSize) &
		(realDataSize = imagDataSize).

	^interpreterProxy failed == false