primitiveFFIIntegerAtPut
	"Store a (signed or unsigned) n byte integer at the given byte offset."
	| isSigned byteSize byteOffset rcvr addr value max valueOop |
	self export: true.
	self inline: false.
	isSigned _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	byteSize _ interpreterProxy stackIntegerValue: 1.
	valueOop _ interpreterProxy stackValue: 2.
	byteOffset _ interpreterProxy stackIntegerValue: 3.
	rcvr _ interpreterProxy stackObjectValue: 4.
	interpreterProxy failed ifTrue:[^0].
	(byteOffset > 0 and:[byteSize = 1 or:[byteSize = 2 or:[byteSize = 4]]])
		ifFalse:[^interpreterProxy primitiveFail].
	addr _ self addressOf: rcvr startingAt: byteOffset size: byteSize.
	interpreterProxy failed ifTrue:[^0].
	isSigned 
		ifTrue:[value _ interpreterProxy signed32BitValueOf: valueOop]
		ifFalse:[value _ interpreterProxy positive32BitValueOf: valueOop].
	interpreterProxy failed ifTrue:[^0].
	byteSize < 4 ifTrue:[
		isSigned ifTrue:[
			max _ 1 << (8 * byteSize - 1).
			value >= max ifTrue:[^interpreterProxy primitiveFail].
			value < (0 - max) ifTrue:[^interpreterProxy primitiveFail].
		] ifFalse:[
			value >= (1 << (8*byteSize)) ifTrue:[^interpreterProxy primitiveFail].
		].
		"short/byte"
		byteSize = 1 
			ifTrue:[interpreterProxy byteAt: addr put: value]
			ifFalse:[	self cCode: '*((short int *) addr) = value' 
						inSmalltalk: [interpreterProxy halfWordAt: addr put: value]].
	] ifFalse:[interpreterProxy longAt: addr put: value].
	interpreterProxy pop: 5.
	^interpreterProxy push: valueOop.