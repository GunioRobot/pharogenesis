primitiveDecodeMCU
	"In:
		anArray 		WordArray of: DCTSize2
		aColorComponent JPEGColorComponent
		dcTable			WordArray
		acTable			WordArray
		stream			JPEGStream
	"
	| arrayOop oop anArray |
	self export: true.
	self var: #anArray type: 'int *'.
	self cCode:'' inSmalltalk:[self stInit].

	interpreterProxy methodArgumentCount = 5 
		ifFalse:[^interpreterProxy primitiveFail].

	oop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	(self loadJPEGStreamFrom: oop)
		ifFalse:[^interpreterProxy primitiveFail].

	arrayOop _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: arrayOop)
		ifFalse:[^interpreterProxy primitiveFail].
	acTableSize _ interpreterProxy slotSizeOf: arrayOop.
	acTable _ interpreterProxy firstIndexableField: arrayOop.

	arrayOop _ interpreterProxy stackObjectValue: 2.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: arrayOop)
		ifFalse:[^interpreterProxy primitiveFail].
	dcTableSize _ interpreterProxy slotSizeOf: arrayOop.
	dcTable _ interpreterProxy firstIndexableField: arrayOop.

	oop _ interpreterProxy stackObjectValue: 3.
	interpreterProxy failed ifTrue:[^nil].
	(self colorComponent: yComponent from: oop)
		ifFalse:[^interpreterProxy primitiveFail].

	arrayOop _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^nil].
	(interpreterProxy isWords: arrayOop)
		ifFalse:[^interpreterProxy primitiveFail].
	(interpreterProxy slotSizeOf: arrayOop) = DCTSize2
		ifFalse:[^interpreterProxy primitiveFail].
	anArray _ interpreterProxy firstIndexableField: arrayOop.

	interpreterProxy failed ifTrue:[^nil].

	self decodeBlockInto: anArray component: yComponent.

	interpreterProxy failed ifTrue:[^nil].
	self storeJPEGStreamOn: (interpreterProxy stackValue: 0).
	interpreterProxy 
		storeInteger: PriorDCValueIndex 
		ofObject: (interpreterProxy stackValue: 3) 
		withValue: (yComponent at: PriorDCValueIndex).

	interpreterProxy pop: 5.