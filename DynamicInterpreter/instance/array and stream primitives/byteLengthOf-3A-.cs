byteLengthOf: oop
	"Return the number of indexable bytes in the given object. This is basically a special copy of lengthOf: for BitBlt."
	| header sz fmt |
	header _ self baseHeader: oop.
	(header bitAnd: TypeMask) = HeaderTypeSizeAndClass
		ifTrue: [ sz _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [ sz _ header bitAnd: 16rFC ].
	fmt _ (header >> 8) bitAnd: 16rF.
	fmt < 8
		ifTrue: [ ^ (sz - BaseHeaderSize)]  "words"
		ifFalse: [ ^ (sz - BaseHeaderSize) - (fmt bitAnd: 3)]  "bytes"