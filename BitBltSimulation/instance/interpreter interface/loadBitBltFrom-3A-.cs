loadBitBltFrom: bbObj
	"Load context from BitBlt instance.  Return false if anything is amiss"
	"NOTE this should all be changed to minX/maxX coordinates for simpler clipping
		-- once it works!"
	| destBitsSize destWidth destHeight sourceBitsSize sourcePixPerWord cmSize halftoneBits |
	bitBltOop _ bbObj.
	combinationRule _ interpreterProxy fetchInteger: BBRuleIndex ofObject: bitBltOop.
	(interpreterProxy failed
		or: [combinationRule < 0 or: [combinationRule > 29]])
		 ifTrue: [^ false  "operation out of range"].
	(combinationRule >= 16 and: [combinationRule <= 17])
		 ifTrue: [^ false  "fail for old simulated paint, erase modes"].
	sourceForm _ interpreterProxy fetchPointer: BBSourceFormIndex ofObject: bitBltOop.
	noSource _ self ignoreSourceOrHalftone: sourceForm.
	halftoneForm _ interpreterProxy fetchPointer: BBHalftoneFormIndex ofObject: bitBltOop.
	noHalftone _ self ignoreSourceOrHalftone: halftoneForm.

	destForm _ interpreterProxy fetchPointer: BBDestFormIndex ofObject: bitBltOop.
		((interpreterProxy isPointers: destForm) and: [(interpreterProxy lengthOf: destForm) >= 4])
			ifFalse: [^ false].
		destBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: destForm.
		destBitsSize _ interpreterProxy byteLengthOf: destBits.
		destWidth _ interpreterProxy fetchInteger: FormWidthIndex ofObject: destForm.
		destHeight _ interpreterProxy fetchInteger: FormHeightIndex ofObject: destForm.
		(destWidth >= 0 and: [destHeight >= 0])
			ifFalse: [^ false].
		destPixSize _ interpreterProxy fetchInteger: FormDepthIndex ofObject: destForm.
		pixPerWord _ 32 // destPixSize.
		destRaster _ destWidth + (pixPerWord-1) // pixPerWord.
		((interpreterProxy isWordsOrBytes: destBits)
			and: [destBitsSize = (destRaster * destHeight * 4)])
			ifFalse: [^ false].	
	destX _ interpreterProxy fetchIntegerOrTruncFloat: BBDestXIndex ofObject: bitBltOop.
	destY _ interpreterProxy fetchIntegerOrTruncFloat: BBDestYIndex ofObject: bitBltOop.
	width _ interpreterProxy fetchIntegerOrTruncFloat: BBWidthIndex ofObject: bitBltOop.
	height _ interpreterProxy fetchIntegerOrTruncFloat: BBHeightIndex ofObject: bitBltOop.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].

	noSource ifTrue:
		[sourceX _ sourceY _ 0]
		ifFalse: 
		[((interpreterProxy isPointers: sourceForm) and: [(interpreterProxy lengthOf: sourceForm) >= 4])
			ifFalse: [^ false].
		sourceBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: sourceForm.
		sourceBitsSize _ interpreterProxy byteLengthOf: sourceBits.
		srcWidth _ interpreterProxy fetchIntegerOrTruncFloat: FormWidthIndex ofObject: sourceForm.
		srcHeight _ interpreterProxy fetchIntegerOrTruncFloat: FormHeightIndex ofObject: sourceForm.
		(srcWidth >= 0 and: [srcHeight >= 0])
			ifFalse: [^ false].
		sourcePixSize _ interpreterProxy fetchInteger: FormDepthIndex ofObject: sourceForm.
		sourcePixPerWord _ 32 // sourcePixSize.
		sourceRaster _ srcWidth + (sourcePixPerWord-1) // sourcePixPerWord.
		((interpreterProxy isWordsOrBytes: sourceBits)
			and: [sourceBitsSize = (sourceRaster * srcHeight * 4)])
			ifFalse: [^ false].
		colorMap _ interpreterProxy fetchPointer: BBColorMapIndex ofObject: bitBltOop.
		"ColorMap, if not nil, must be longWords, and 
		2^N long, where N = sourcePixSize for 1, 2, 4, 8 bits, 
		or N = 9, 12, or 15 (3, 4, 5 bits per color) for 16 or 32 bits."
		colorMap = interpreterProxy nilObject ifFalse:
			[(interpreterProxy isWords: colorMap)
			ifTrue:
			[cmSize _ interpreterProxy lengthOf: colorMap.
			cmBitsPerColor _ 0.
			cmSize = 512 ifTrue: [cmBitsPerColor _ 3].
			cmSize = 4096 ifTrue: [cmBitsPerColor _ 4].
			cmSize = 32768 ifTrue: [cmBitsPerColor _ 5].
			interpreterProxy primIndex ~= 147 ifTrue:
				["WarpBlt has different checks on the color map"
				sourcePixSize <= 8
				ifTrue: [cmSize = (1 << sourcePixSize) ifFalse: [^ false] ]
				ifFalse: [cmBitsPerColor = 0 ifTrue: [^ false] ]]
			]
			ifFalse: [^ false]].
		sourceX _ interpreterProxy fetchIntegerOrTruncFloat: BBSourceXIndex ofObject: bitBltOop.
		sourceY _ interpreterProxy fetchIntegerOrTruncFloat: BBSourceYIndex ofObject: bitBltOop].

	noHalftone ifFalse: 
		[((interpreterProxy isPointers: halftoneForm) and: [(interpreterProxy lengthOf: halftoneForm) >= 4])
		ifTrue:
		["Old-style 32xN monochrome halftone Forms"
		halftoneBits _ interpreterProxy fetchPointer: FormBitsIndex ofObject: halftoneForm.
		halftoneHeight _ interpreterProxy fetchInteger: FormHeightIndex ofObject: halftoneForm.
		(interpreterProxy isWords: halftoneBits)
			ifFalse: [noHalftone _ true]]
		ifFalse:
		["New spec accepts, basically, a word array"
		((interpreterProxy isPointers: halftoneForm) not
			and: [interpreterProxy isWords: halftoneForm])
			ifFalse: [^ false].
		halftoneBits _ halftoneForm.
		halftoneHeight _ interpreterProxy lengthOf: halftoneBits].
	halftoneBase _ halftoneBits + 4].

	clipX _ interpreterProxy fetchIntegerOrTruncFloat: BBClipXIndex ofObject: bitBltOop.
	clipY _ interpreterProxy fetchIntegerOrTruncFloat: BBClipYIndex ofObject: bitBltOop.
	clipWidth _ interpreterProxy fetchIntegerOrTruncFloat: BBClipWidthIndex ofObject: bitBltOop.
	clipHeight _ interpreterProxy fetchIntegerOrTruncFloat: BBClipHeightIndex ofObject: bitBltOop.
		interpreterProxy failed ifTrue: [^ false  "non-integer value"].
	clipX < 0 ifTrue: [clipWidth _ clipWidth + clipX.  clipX _ 0].
	clipY < 0 ifTrue: [clipHeight _ clipHeight + clipY.  clipY _ 0].
	clipX+clipWidth > destWidth ifTrue: [clipWidth _ destWidth - clipX].
	clipY+clipHeight > destHeight ifTrue: [clipHeight _ destHeight - clipY].

	^ true