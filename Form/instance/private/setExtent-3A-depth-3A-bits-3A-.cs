setExtent: extent depth: bitsPerPixel bits: bitmap
	"Create a virtual bit map with the given extent and bitsPerPixel."

	width _ extent x asInteger.
	width < 0 ifTrue: [width _ 0].
	height _ extent y asInteger.
	height < 0 ifTrue: [height _ 0].
	depth _ bitsPerPixel.
	(bits isNil or:[self bitsSize = bitmap size]) ifFalse:[^self error:'Bad dimensions'].
	bits _ bitmap