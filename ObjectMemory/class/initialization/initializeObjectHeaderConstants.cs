initializeObjectHeaderConstants

	BaseHeaderSize _ 4.

	"masks for type field"
	TypeMask _ 3.
	AllButTypeMask _ 16rFFFFFFFF - TypeMask.

	"type field values"
	HeaderTypeSizeAndClass _ 0.
	HeaderTypeClass _ 1.
	HeaderTypeFree _ 2.
	HeaderTypeShort _ 3.

	"type field values used during the mark phase of GC"
	HeaderTypeGC _ 2.
	GCTopMarker _ 3.  "neither an oop, nor an oop+1, this value signals that we have crawled back up to the top of the marking phase."

	"base header word bit fields"
	HashBits _ 16r1FFE0000.
	AllButHashBits _ 16rFFFFFFFF - HashBits.
	HashBitsOffset _ 17.
	SizeMask _ 16rFC.
	CompactClassMask _ 16r1F000.

	"masks for root and mark bits"
	MarkBit _ 16r80000000.
	RootBit _ 16r40000000.
	AllButMarkBit _ 16rFFFFFFFF - MarkBit.
	AllButRootBit _ 16rFFFFFFFF - RootBit.

	AllButMarkBitAndTypeMask _ AllButTypeMask - MarkBit.