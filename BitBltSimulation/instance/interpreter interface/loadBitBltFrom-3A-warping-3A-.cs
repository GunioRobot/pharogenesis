loadBitBltFrom: bbObj warping: aBool
	"Load context from BitBlt instance.  Return false if anything is amiss"
	"NOTE this should all be changed to minX/maxX coordinates for simpler clipping
		-- once it works!"
	| ok |
	self inline: false.
	bitBltOop _ bbObj.
	isWarping _ aBool.
	combinationRule _ interpreterProxy fetchInteger: BBRuleIndex ofObject: bitBltOop.
	(interpreterProxy failed
		or: [combinationRule < 0 or: [combinationRule > (OpTableSize - 2)]])
		 ifTrue: [^ false  "operation out of range"].
	(combinationRule >= 16 and: [combinationRule <= 17])
		 ifTrue: [^ false  "fail for old simulated paint, erase modes"].
	sourceForm _ interpreterProxy fetchPointer: BBSourceFormIndex ofObject: bitBltOop.
	noSource _ self ignoreSourceOrHalftone: sourceForm.
	halftoneForm _ interpreterProxy fetchPointer: BBHalftoneFormIndex ofObject: bitBltOop.
	noHalftone _ self ignoreSourceOrHalftone: halftoneForm.

	destForm _ interpreterProxy fetchPointer: BBDestFormIndex ofObject: bbObj.
	((interpreterProxy isPointers: destForm) and: [(interpreterProxy slotSizeOf: destForm) >= 4])
		ifFalse: [^ false].
	ok _ self loadBitBltDestForm.
	ok ifFalse:[^false].

	destX _ self fetchIntOrFloat: BBDestXIndex ofObject: bitBltOop ifNil: 0.
	destY _ self fetchIntOrFloat: BBDestYIndex ofObject: bitBltOop ifNil: 0.
	width _ self fetchIntOrFloat: BBWidthIndex ofObject: bitBltOop ifNil: destWidth.
	height _ self fetchIntOrFloat: BBHeightIndex ofObject: bitBltOop ifNil: destHeight.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].

	noSource ifTrue:
		[sourceX _ sourceY _ 0]
		ifFalse: 
		[((interpreterProxy isPointers: sourceForm) and: [(interpreterProxy slotSizeOf: sourceForm) >= 4])
			ifFalse: [^ false].
		ok _ self loadBitBltSourceForm.
		ok ifFalse:[^false].
		ok _ self loadColorMap.
		ok ifFalse:[^false].
		"Need the implicit setup here in case of 16<->32 bit conversions"
		(cmFlags bitAnd: ColorMapNewStyle) = 0 ifTrue:[self setupColorMasks].
		sourceX _ self fetchIntOrFloat: BBSourceXIndex ofObject: bitBltOop ifNil: 0.
		sourceY _ self fetchIntOrFloat: BBSourceYIndex ofObject: bitBltOop ifNil: 0].

	ok _ self loadHalftoneForm.
	ok ifFalse:[^false].
	clipX _ self fetchIntOrFloat: BBClipXIndex ofObject: bitBltOop ifNil: 0.
	clipY _ self fetchIntOrFloat: BBClipYIndex ofObject: bitBltOop ifNil: 0.
	clipWidth _ self fetchIntOrFloat: BBClipWidthIndex ofObject: bitBltOop ifNil: destWidth.
	clipHeight _ self fetchIntOrFloat: BBClipHeightIndex ofObject: bitBltOop ifNil: destHeight.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].
	clipX < 0 ifTrue: [clipWidth _ clipWidth + clipX.  clipX _ 0].
	clipY < 0 ifTrue: [clipHeight _ clipHeight + clipY.  clipY _ 0].
	clipX+clipWidth > destWidth ifTrue: [clipWidth _ destWidth - clipX].
	clipY+clipHeight > destHeight ifTrue: [clipHeight _ destHeight - clipY].
	^ true