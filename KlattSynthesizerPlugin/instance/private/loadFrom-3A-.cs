loadFrom: klattOop
	| oop |
	interpreterProxy success: (interpreterProxy slotSizeOf: klattOop) = 22.
	interpreterProxy failed ifTrue:[^ false].

	oop _ interpreterProxy fetchPointer: 0 ofObject: klattOop.
	resonators _ self checkedFloatPtrOf: oop.

	pitch _ interpreterProxy fetchFloat: 2 ofObject: klattOop.
	t0 _ interpreterProxy fetchInteger: 3 ofObject: klattOop.
	nper _ interpreterProxy fetchInteger: 4 ofObject: klattOop.
	nopen _ interpreterProxy fetchInteger: 5 ofObject: klattOop.
	nmod _ interpreterProxy fetchInteger: 6 ofObject: klattOop.
	a1 _ interpreterProxy fetchFloat: 7 ofObject: klattOop.
	a2 _ interpreterProxy fetchFloat: 8 ofObject: klattOop.
	x1 _ interpreterProxy fetchFloat: 9 ofObject: klattOop.
	x2 _ interpreterProxy fetchFloat: 10 ofObject: klattOop.
	b1 _ interpreterProxy fetchFloat: 11 ofObject: klattOop.
	c1 _ interpreterProxy fetchFloat: 12 ofObject: klattOop.
	glast _ interpreterProxy fetchFloat: 13 ofObject: klattOop.
	vlast _ interpreterProxy fetchFloat: 14 ofObject: klattOop.
	nlast _ interpreterProxy fetchFloat: 15 ofObject: klattOop.
	periodCount _ interpreterProxy fetchInteger: 16 ofObject: klattOop.
	samplesCount _ interpreterProxy fetchInteger: 17 ofObject: klattOop.
	seed _ interpreterProxy fetchInteger: 18 ofObject: klattOop.
	cascade _ interpreterProxy fetchInteger: 19 ofObject: klattOop.
	samplesPerFrame _ interpreterProxy fetchInteger: 20 ofObject: klattOop.
	samplingRate _ interpreterProxy fetchInteger: 21 ofObject: klattOop.

	^ interpreterProxy failed == false