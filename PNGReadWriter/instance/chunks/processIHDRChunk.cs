processIHDRChunk
	width _ chunk longAt: 1 bigEndian: true.
	height _ chunk longAt: 5 bigEndian: true.
	bitsPerChannel _ chunk at: 9.
	colorType _ chunk at: 10.
	"compression _ chunk at: 11." "TODO - validate compression"
	"filterMethod _ chunk at: 12." "TODO - validate filterMethod"
	interlaceMethod _ chunk at: 13. "TODO - validate interlace method"
	(#(2 4 6) includes: colorType)
		ifTrue: [
			depth _ 32.
			form _ Form extent: width@height depth: depth
			].
	(#(0 3) includes: colorType)
		ifTrue: [
			depth _ bitsPerChannel min: 8.
			form _ ColorForm extent: width@height depth: depth.
			colorType = 0 ifTrue: [ "grayscale"
				form colors: (self grayColorsFor: depth).
				]
			].
	bitsPerPixel _ (BPP at: colorType+1) at: bitsPerChannel highBit.
	bytesPerScanline _ width * bitsPerPixel + 7 // 8.
	rowSize _ form width * form depth + 31 >> 5.
