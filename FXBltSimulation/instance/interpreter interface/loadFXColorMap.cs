loadFXColorMap
	"Load a color map from FXBlt"
	| oop cmSize |
	self inline: true.
	oop _ interpreterProxy fetchPointer: BBColorMapIndex ofObject: bitBltOop.
	oop = interpreterProxy nilObject ifTrue:[^noColorMap _ true].
	"We have a colorMap even though it might be that it's just an identity mapping"
	noColorMap _ false.
	((interpreterProxy isPointers: oop) 
		and:[(interpreterProxy slotSizeOf: oop) >= 3]) ifFalse:[^false].
	cmShiftTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 0 ofObject: oop).
	cmMaskTable _ self loadFXShiftOrMaskFrom:
		(interpreterProxy fetchPointer: 1 ofObject: oop).
	oop _ interpreterProxy fetchPointer: 2 ofObject: oop.
	oop = interpreterProxy nilObject 
		ifTrue:[cmSize _ cmMask _ 0]
		ifFalse:[(interpreterProxy isWords: oop) ifFalse:[^false].
				cmSize _ (interpreterProxy slotSizeOf: oop)].
	(cmSize bitAnd: cmSize - 1) = 0 ifFalse:[^false].
	cmSize = 0 
		ifTrue:[colorMap _ nil]
		ifFalse:[colorMap _ interpreterProxy firstIndexableField: oop.
				cmMask _ cmSize - 1].
	"Check if colorMap is just identity mapping for RGBA parts"
	(self isIdentityMap: cmShiftTable with: cmMaskTable)
		ifTrue:[ cmMaskTable _ cmShiftTable _ nil ].
	^true