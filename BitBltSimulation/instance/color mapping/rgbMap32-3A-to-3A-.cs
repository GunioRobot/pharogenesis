rgbMap32: sourcePixel to: nBitsOut
	"Convert the given 32bit pixel value to a color map index 
	using nBitsOut bits for each color component. 
	Note: This method is intended to deal with different source formats."
	| delta |
	self inline: true.
	delta _ 8 - nBitsOut.
	"note: evaluated strictly left to right"
	^((sourcePixel >> 16 bitAnd: 255) >> delta) << nBitsOut +
		((sourcePixel >> 8 bitAnd: 255) >> delta) << nBitsOut +
			((sourcePixel bitAnd: 255) >> delta)