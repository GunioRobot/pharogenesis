primitiveMapFromToWidthHeightPatchSizeRgbFlagsShift

	| srcOop dstOop w h patchSize rgbFlags shiftAmount src dst rgbMult srcIndex level pixel offset |
	self export: true.
	self var: 'src' declareC: 'unsigned int *src'.
	self var: 'dst' declareC: 'unsigned int *dst'.

	srcOop _ interpreterProxy stackValue: 6.
	dstOop _ interpreterProxy stackValue: 5.
	w _ interpreterProxy stackIntegerValue: 4.
	h _ interpreterProxy stackIntegerValue: 3.
	patchSize _ interpreterProxy stackIntegerValue: 2.
	rgbFlags _ interpreterProxy stackIntegerValue: 1.
	shiftAmount _ interpreterProxy stackIntegerValue: 0.

	src _ self checkedUnsignedIntPtrOf: srcOop.
	dst _ self checkedUnsignedIntPtrOf: dstOop.
	interpreterProxy success:
		(interpreterProxy stSizeOf: dstOop) = (w * h).
	interpreterProxy success:
		(interpreterProxy stSizeOf: dstOop) = ((interpreterProxy stSizeOf: srcOop) * patchSize * patchSize).
	interpreterProxy failed ifTrue: [^ nil].

	rgbMult _ 0.
	(rgbFlags bitAnd: 2r100) > 0 ifTrue: [rgbMult _ rgbMult + 16r10000].
	(rgbFlags bitAnd: 2r10) > 0 ifTrue: [rgbMult _ rgbMult + 16r100].
	(rgbFlags bitAnd: 2r1) > 0 ifTrue: [rgbMult _ rgbMult + 16r1].
	srcIndex _ -1.
	0 to: (h // patchSize) - 1 do: [:y |
		0 to: (w // patchSize) - 1 do: [:x |
			level _ (src at: (srcIndex _ srcIndex + 1)) bitShift: shiftAmount.
			level > 255 ifTrue: [level _ 255].
			level <= 0
				ifTrue: [pixel _ 1]  "non-transparent black"
				ifFalse: [pixel _ level * rgbMult].

			"fill a patchSize x patchSize square with the pixel value"
			offset _ ((y * w) + x) * patchSize.
			offset to: offset + ((patchSize - 1) * w) by: w do: [:rowStart |
				rowStart to: rowStart + patchSize - 1 do: [:dstIndex |
					dst at: dstIndex put: pixel]] ]].

	interpreterProxy pop: 7.  "pop args, leave rcvr on stack"
