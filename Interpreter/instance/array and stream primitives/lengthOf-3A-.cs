lengthOf: oop
	"Return the number of indexable bytes or words in the given object. Assume the argument is not an integer. For a CompiledMethod, the size of the method header (in bytes) should be subtracted from the result."

	| header sz fmt |
	self inline: true.
	"from ObjectMemory>sizeBitsOf:..."
	header _ self baseHeader: oop.
	(header bitAnd: TypeMask) = HeaderTypeSizeAndClass
		ifTrue: [ sz _ (self sizeHeader: oop) bitAnd: AllButTypeMask ]
		ifFalse: [ sz _ header bitAnd: 16rFC ].

	"from ObjectMemory>formatOf:..."
	fmt _ (header >> 8) bitAnd: 16rF.

	fmt < 8
		ifTrue: [ ^ (sz - BaseHeaderSize) >> 2 ]  "words"
		ifFalse: [ ^ (sz - BaseHeaderSize) - (fmt bitAnd: 3) ]  "bytes"