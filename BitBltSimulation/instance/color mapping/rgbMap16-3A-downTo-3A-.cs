rgbMap16: sourcePixel downTo: nBitsOut
	"Convert the given 16bit pixel value to a color map index 
	using nBitsOut bits for each color component. 
	Note: This method is intended to deal with different source formats."
	| delta |
	self inline: true.
	delta _ 5 - nBitsOut.
	"note: evaluated strictly left to right"
	^((sourcePixel >> 10 bitAnd: 31) >> delta) << nBitsOut +
		((sourcePixel >> 5 bitAnd: 31) >> delta) << nBitsOut +
			((sourcePixel bitAnd: 31) >> delta)