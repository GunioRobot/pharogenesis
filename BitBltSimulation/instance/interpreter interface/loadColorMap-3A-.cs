loadColorMap: warping
	"ColorMap, if not nil, must be longWords, and 
	2^N long, where N = sourcePixSize for 1, 2, 4, 8 bits, 
	or N = 9, 12, or 15 (3, 4, 5 bits per color) for 16 or 32 bits."
	| cmSize |
	self inline: true.
	cmBitsPerColor _ 0.
	colorMap = interpreterProxy nilObject ifTrue:[
		colorMap _ nil.
	] ifFalse:[
		(interpreterProxy isWords: colorMap) ifTrue:[
			cmSize _ interpreterProxy slotSizeOf: colorMap.
			cmSize = 512 ifTrue: [cmBitsPerColor _ 3].
			cmSize = 4096 ifTrue: [cmBitsPerColor _ 4].
			cmSize = 32768 ifTrue: [cmBitsPerColor _ 5].
			warping ifFalse:[
				"WarpBlt has different checks on the color map"
				sourcePixSize <= 8
					ifTrue: [cmSize = (1 << sourcePixSize) ifFalse: [^ false] ]
					ifFalse: [cmBitsPerColor = 0 ifTrue: [^ false] ]].
			colorMap _ self cCoerce: (interpreterProxy firstIndexableField: colorMap) to: 'int'.
			self setupColorMasks.
		] ifFalse: [^ false]].
	^true