ImageReadWriter
	subclass: #GIFReadWriter
	instanceVariableNames:
		'width height bitsPerPixel depth colorPalette rowByteSize xpos ypos pass interlace codeSize clearCode eoiCode freeCode maxCode prefixTable suffixTable remainBitCount bufByte bufStream transparentIndex mapOf32 '
	classVariableNames: 'Extension ImageSeparator Terminator '
	poolDictionaries: ''
	category: 'Graphics-Files'