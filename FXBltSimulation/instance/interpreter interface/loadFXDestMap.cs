loadFXDestMap
	"Load a destination map from destForm to canonical 32bit RGBA values"
	| oop dmSize |
	self inline: true.
	oop _ interpreterProxy fetchPointer: FXDestMapIndex ofObject: bitBltOop.
	oop = interpreterProxy nilObject ifTrue:[^noDestMap _ true].
	"We have a destMap even though it might be that it's just an identity mapping"
	noDestMap _ false.
	((interpreterProxy isPointers: oop) 
		and:[(interpreterProxy slotSizeOf: oop) >= 3]) ifFalse:[^false].
	dmShiftTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 0 ofObject: oop).
	dmMaskTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 1 ofObject: oop).
	oop _ interpreterProxy fetchPointer: 2 ofObject: oop.
	oop = interpreterProxy nilObject 
		ifTrue:[dmSize _ dmMask _ 0]
		ifFalse:[(interpreterProxy isWords: oop) ifFalse:[^false].
				dmSize _ (interpreterProxy slotSizeOf: oop)].
	(dmSize bitAnd: dmSize - 1) = 0 ifFalse:[^false].
	dmSize = 0 
		ifTrue:[destMap _ nil]
		ifFalse:[destMap _ interpreterProxy firstIndexableField: oop.
				dmMask _ dmSize - 1].
	"Check if destMap is just identity mapping for RGBA parts"
	(self isIdentityMap: dmShiftTable with: dmMaskTable)
		ifTrue:[ dmMaskTable _ dmShiftTable _ nil ].
	^true