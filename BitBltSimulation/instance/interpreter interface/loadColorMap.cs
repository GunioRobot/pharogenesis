loadColorMap
	"ColorMap, if not nil, must be longWords, and 
	2^N long, where N = sourceDepth for 1, 2, 4, 8 bits, 
	or N = 9, 12, or 15 (3, 4, 5 bits per color) for 16 or 32 bits."
	| cmSize oldStyle oop cmOop |
	self inline: true.
	cmFlags _ cmMask _ cmBitsPerColor _ 0.
	cmShiftTable _ nil.
	cmMaskTable _ nil.
	cmLookupTable _ nil.
	cmOop _ interpreterProxy fetchPointer: BBColorMapIndex ofObject: bitBltOop.
	cmOop = interpreterProxy nilObject ifTrue:[^true].
	cmFlags _ ColorMapPresent. "even if identity or somesuch - may be cleared later"
	oldStyle _ false.
	(interpreterProxy isWords: cmOop) ifTrue:[
		"This is an old-style color map (indexed only, with implicit RGBA conversion)"
		cmSize _ interpreterProxy slotSizeOf: cmOop.
		cmLookupTable _ interpreterProxy firstIndexableField: cmOop.
		oldStyle _ true.
	] ifFalse: [
		"A new-style color map (fully qualified)"
		((interpreterProxy isPointers: cmOop) 
			and:[(interpreterProxy slotSizeOf: cmOop) >= 3]) ifFalse:[^false].
		cmShiftTable _ self loadColorMapShiftOrMaskFrom:
			(interpreterProxy fetchPointer: 0 ofObject: cmOop).
		cmMaskTable _ self loadColorMapShiftOrMaskFrom:
			(interpreterProxy fetchPointer: 1 ofObject: cmOop).
		oop _ interpreterProxy fetchPointer: 2 ofObject: cmOop.
		oop = interpreterProxy nilObject 
			ifTrue:[cmSize _ 0]
			ifFalse:[(interpreterProxy isWords: oop) ifFalse:[^false].
					cmSize _ (interpreterProxy slotSizeOf: oop).
					cmLookupTable _ interpreterProxy firstIndexableField: oop].
		cmFlags _ cmFlags bitOr: ColorMapNewStyle.
	].
	(cmSize bitAnd: cmSize - 1) = 0 ifFalse:[^false].
	cmMask _ cmSize - 1.
	cmBitsPerColor _ 0.
	cmSize = 512 ifTrue: [cmBitsPerColor _ 3].
	cmSize = 4096 ifTrue: [cmBitsPerColor _ 4].
	cmSize = 32768 ifTrue: [cmBitsPerColor _ 5].
	cmSize = 0
		ifTrue:[cmLookupTable _ nil. cmMask _ 0]
		ifFalse:[cmFlags _ cmFlags bitOr: ColorMapIndexedPart].
	oldStyle "needs implicit conversion"
		ifTrue:[	self setupColorMasks].
	"Check if colorMap is just identity mapping for RGBA parts"
	(self isIdentityMap: cmShiftTable with: cmMaskTable)
		ifTrue:[ cmMaskTable _ nil. cmShiftTable _ nil ]
		ifFalse:[ cmFlags _ cmFlags bitOr: ColorMapFixedPart].
	^true