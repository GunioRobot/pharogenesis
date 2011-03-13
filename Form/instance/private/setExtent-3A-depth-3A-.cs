setExtent: extent depth: bitsPerPixel
	"Create a virtual bit map with the given extent and bitsPerPixel."

	width _ extent x.
	width < 0 ifTrue: [width _ 0].
	height _ extent y.
	height < 0 ifTrue: [height _ 0].
	depth _ bitsPerPixel.
	bits _ Bitmap new: self bitsSize