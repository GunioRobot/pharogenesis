lengthOf: oop baseHeader: hdr format: fmt
	"Return the number of indexable bytes or words in the given object. Assume the given oop is not an integer. For a CompiledMethod, the size of the method header (in bytes) should be subtracted from the result of this method."

	| sz |
	self inline: true.
	(hdr bitAnd: TypeMask) = HeaderTypeSizeAndClass
		ifTrue: [ sz _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [ sz _ hdr bitAnd: 16rFC ].

	fmt < 8
		ifTrue: [ ^ (sz - BaseHeaderSize) >> 2 ]  "words"
		ifFalse: [ ^ (sz - BaseHeaderSize) - (fmt bitAnd: 3) ]  "bytes"