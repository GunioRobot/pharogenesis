primitiveIdctInt
	"In:
		anArray: IntegerArray new: DCTSize2
		qt: IntegerArray new: DCTSize2.
	"
	| arrayOop anArray qt |
	self export: true.
	self var: #anArray type: 'int *'.
	self var: #qt type: 'int *'.
	self cCode:'' inSmalltalk:[self stInit].
	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	arrayOop _ interpreterProxy stackObjectValue: 0.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isWords: arrayOop) and:[(interpreterProxy slotSizeOf: arrayOop) = DCTSize2])
		ifFalse:[^interpreterProxy primitiveFail].
	qt _ interpreterProxy firstIndexableField: arrayOop.
	arrayOop _ interpreterProxy stackObjectValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	((interpreterProxy isWords: arrayOop) and:[(interpreterProxy slotSizeOf: arrayOop) = DCTSize2])
		ifFalse:[^interpreterProxy primitiveFail].
	anArray _ interpreterProxy firstIndexableField: arrayOop.
	self idctBlockInt: anArray qt: qt.
	interpreterProxy pop: 2.