setExtent: extent depth: bitsPerPixel bits: bitOrPixmap rgbaBitMasks: bitMasks handle: aHandle renderer: aRenderer
	width _ extent x asInteger.
	width < 0 ifTrue: [width _ 0].
	height _ extent y asInteger.
	height < 0 ifTrue: [height _ 0].
	depth _ bitsPerPixel.
	bits _ bitOrPixmap.
	argbMap _ ColorMap mappingFromARGB: bitMasks.
	handle _ aHandle.
	renderer _ aRenderer.