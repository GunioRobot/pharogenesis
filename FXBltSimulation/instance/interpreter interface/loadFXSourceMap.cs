loadFXSourceMap
	"Load a source map from sourceForm to canonical 32bit RGBA values"
	| oop smSize |
	self inline: true.
	noSource ifTrue:[^true].
	oop _ interpreterProxy fetchPointer: FXSourceMapIndex ofObject: bitBltOop.
	oop = interpreterProxy nilObject ifTrue:[^noSourceMap _ true].
	"We have a sourceMap even though it might be that it's just an identity mapping"
	noSourceMap _ false.
	((interpreterProxy isPointers: oop) 
		and:[(interpreterProxy slotSizeOf: oop) >= 3]) ifFalse:[^false].
	smShiftTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 0 ofObject: oop).
	smMaskTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 1 ofObject: oop).
	oop _ interpreterProxy fetchPointer: 2 ofObject: oop.
	oop = interpreterProxy nilObject 
		ifTrue:[smSize _ smMask _ 0]
		ifFalse:[(interpreterProxy isWords: oop) ifFalse:[^false].
				smSize _ (interpreterProxy slotSizeOf: oop)].
	(smSize bitAnd: smSize - 1) = 0 ifFalse:[^false].
	smSize = 0 
		ifTrue:[sourceMap _ nil]
		ifFalse:[sourceMap _ interpreterProxy firstIndexableField: oop.
				smMask _ smSize - 1].
	"Check if sourceMap is just identity mapping for RGBA parts"
	(self isIdentityMap: smShiftTable with: smMaskTable)
		ifTrue:[ smMaskTable _ smShiftTable _ nil ].
	^true