loadBitBltFrom: bbObj warping: aBool
	"Load context from BitBlt instance.  Return false if anything is amiss"
	"NOTE this should all be changed to minX/maxX coordinates for simpler clipping
		-- once it works!"
	| ok |
	self inline: false.
	bitBltOop _ bbObj.
	colorMap _ nil. "Assume no color map"
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

	destX _ self fetchIntOrFloat: BBDestXIndex ofObject: bitBltOop.
	destY _ self fetchIntOrFloat: BBDestYIndex ofObject: bitBltOop.
	width _ self fetchIntOrFloat: BBWidthIndex ofObject: bitBltOop.
	height _ self fetchIntOrFloat: BBHeightIndex ofObject: bitBltOop.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].

	noSource ifTrue:
		[sourceX _ sourceY _ 0]
		ifFalse: 
		[((interpreterProxy isPointers: sourceForm) and: [(interpreterProxy slotSizeOf: sourceForm) >= 4])
			ifFalse: [^ false].
		ok _ self loadBitBltSourceForm.
		ok ifFalse:[^false].
		colorMap _ interpreterProxy fetchPointer: BBColorMapIndex ofObject: bitBltOop.
		ok _ self loadColorMap: aBool.
		ok ifFalse:[^false].
		self setupColorMasks.
		sourceX _ self fetchIntOrFloat: BBSourceXIndex ofObject: bitBltOop.
		sourceY _ self fetchIntOrFloat: BBSourceYIndex ofObject: bitBltOop].

	ok _ self loadHalftoneForm.
	ok ifFalse:[^false].
	clipX _ self fetchIntOrFloat: BBClipXIndex ofObject: bitBltOop.
	clipY _ self fetchIntOrFloat: BBClipYIndex ofObject: bitBltOop.
	clipWidth _ self fetchIntOrFloat: BBClipWidthIndex ofObject: bitBltOop.
	clipHeight _ self fetchIntOrFloat: BBClipHeightIndex ofObject: bitBltOop.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].
	clipX < 0 ifTrue: [clipWidth _ clipWidth + clipX.  clipX _ 0].
	clipY < 0 ifTrue: [clipHeight _ clipHeight + clipY.  clipY _ 0].
	clipX+clipWidth > destWidth ifTrue: [clipWidth _ destWidth - clipX].
	clipY+clipHeight > destHeight ifTrue: [clipHeight _ destHeight - clipY].
	^ true