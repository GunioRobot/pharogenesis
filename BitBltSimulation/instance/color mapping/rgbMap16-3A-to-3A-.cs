rgbMap16: sourcePixel to: nBitsOut
	"Convert the given 16bit pixel value to a color map index 
	using nBitsOut bits for each color component. 
	Note: This method is intended to deal with different source formats."
	self inline: true.
	nBitsOut > 5
		ifTrue:[^self rgbMap16: sourcePixel upTo: nBitsOut]
		ifFalse:[^self rgbMap16: sourcePixel downTo: nBitsOut]