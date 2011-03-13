ImageReadWriter
	subclass: #PNGReadWriter
	instanceVariableNames:
		'chunk form width height depth bitsPerChannel colorType interlaceMethod bitsPerPixel bytesPerScanline thisScanline prevScanline rowSize globalDataChunk unknownChunks palette transparentPixelValue filtersSeen '
	classVariableNames: 'BPP BlockHeight BlockWidth Debugging '
	poolDictionaries: ''
	category: 'Graphics-Files'