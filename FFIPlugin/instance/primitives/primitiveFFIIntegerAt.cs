primitiveFFIIntegerAt
	"Return a (signed or unsigned) n byte integer from the given byte offset."
	| isSigned byteSize byteOffset rcvr addr value mask |
	self export: true.
	self inline: false.
	isSigned _ interpreterProxy booleanValueOf: (interpreterProxy stackValue: 0).
	byteSize _ interpreterProxy stackIntegerValue: 1.
	byteOffset _ interpreterProxy stackIntegerValue: 2.
	rcvr _ interpreterProxy stackObjectValue: 3.
	interpreterProxy failed ifTrue:[^0].
	(byteOffset > 0 and:[byteSize = 1 or:[byteSize = 2 or:[byteSize = 4]]])
		ifFalse:[^interpreterProxy primitiveFail].
	addr _ self addressOf: rcvr startingAt: byteOffset size: byteSize.
	interpreterProxy failed ifTrue:[^0].
	byteSize < 4 ifTrue:[
		"short/byte"
		byteSize = 1 
			ifTrue:[value _ interpreterProxy byteAt: addr]
			ifFalse:[	value _ self cCode: '*((short int *) addr)' 
								inSmalltalk: [interpreterProxy halfWordAt: addr]].
		isSigned ifTrue:["sign extend value"
			mask _ 1 << (byteSize * 8 - 1).
			value _ (value bitAnd: mask-1) - (value bitAnd: mask)].
		"note: byte/short never exceed SmallInteger range"
		value _ interpreterProxy integerObjectOf: value.
	] ifFalse:[
		"general 32 bit integer"
		value _ interpreterProxy longAt: addr.
		isSigned
			ifTrue:[value _ interpreterProxy signed32BitIntegerFor: value]
			ifFalse:[value _ interpreterProxy positive32BitIntegerFor: value].
	].
	interpreterProxy pop: 4.
	^interpreterProxy push: value
