instantiateSmallClass: classPointer sizeInBytes: sizeInBytes fill: fillValue
	"This version of instantiateClass assumes that the total object size is under 256 bytes, the limit for objects with only one or two header words. Note that the size is specified in bytes and should include four bytes for the base header word."

	| hash header1 header2 hdrSize |
	hash _ self newObjectHash.
	header1 _ ((hash << 17) bitAnd: 16r1FFE0000) bitOr:
			   (self formatOfClass: classPointer).
	header1 _ header1 + (sizeInBytes - (header1 bitAnd: 16rFC)).
	header2 _ classPointer.

	(header1 bitAnd: 16r1F000) = 0 "is compact class field from format word zero?"
		ifTrue: [ hdrSize _ 2 ]
		ifFalse: [ hdrSize _ 1 ].

	^ self allocate: sizeInBytes headerSize: hdrSize h1: header1 h2: header2 h3: 0 fill: fillValue