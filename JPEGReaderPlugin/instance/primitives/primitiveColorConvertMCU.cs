primitiveColorConvertMCU
	"Requires:
		Array with: 3*JPEGColorComponent
		bits
		WordArray with: 3*Integer (residuals)
		ditherMask
	"
	| arrayOop |
	self export: true.
	self stInit.
	interpreterProxy methodArgumentCount = 4
		ifFalse:[^interpreterProxy primitiveFail].
	ditherMask _ interpreterProxy stackIntegerValue: 0.
	arrayOop _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isWords: arrayOop) and:[(interpreterProxy slotSizeOf: arrayOop) = 3])
		ifFalse:[^interpreterProxy primitiveFail].
	residuals _ interpreterProxy firstIndexableField: arrayOop.
	arrayOop _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: arrayOop)
		ifFalse:[^interpreterProxy primitiveFail].
	jpegBitsSize _ interpreterProxy slotSizeOf: arrayOop.
	jpegBits _ interpreterProxy firstIndexableField: arrayOop.
	arrayOop _ interpreterProxy stackObjectValue: 3.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isPointers: arrayOop) and:[(interpreterProxy slotSizeOf: arrayOop) = 3])
		ifFalse:[^interpreterProxy primitiveFail].
	(self yColorComponentFrom: (interpreterProxy fetchPointer: 0 ofObject: arrayOop))
		ifFalse:[^interpreterProxy primitiveFail].
	(self cbColorComponentFrom: (interpreterProxy fetchPointer: 1 ofObject: arrayOop))
		ifFalse:[^interpreterProxy primitiveFail].
	(self crColorComponentFrom: (interpreterProxy fetchPointer: 2 ofObject: arrayOop))
		ifFalse:[^interpreterProxy primitiveFail].
	self colorConvertMCU.
	interpreterProxy pop: 4.