fromBMPFileNamed: fileName
	"Form fromBMPFileNamed: 'FulS.bmp'"

	| f bfType bfSize bfReserved bfOffBits biSize biWidth biHeight
	  biPlanes biBitCount biCompression form pixelLine pixIndex rgb rowBytes line data |
	f _ (FileStream oldFileNamed: fileName) binary.
	bfType _ f nextLitteEndianNumber: 2.
	bfSize _ f nextLitteEndianNumber: 4.
	bfReserved _ f nextLitteEndianNumber: 4.
	bfOffBits _ f nextLitteEndianNumber: 4.
	biSize _ f nextLitteEndianNumber: 4.
	biWidth _ f nextLitteEndianNumber: 4.
	biHeight _ f nextLitteEndianNumber: 4.
	biPlanes _ f nextLitteEndianNumber: 2.
	biBitCount _ f nextLitteEndianNumber: 2.
	biCompression _ f nextLitteEndianNumber: 4.
	f nextLitteEndianNumber: 4.  "biSizeImage"
	f nextLitteEndianNumber: 4.  "biXPelsPerMeter"
	f nextLitteEndianNumber: 4.  "biYPelsPerMeter"
	f nextLitteEndianNumber: 4.  "biClrUsed"
	f nextLitteEndianNumber: 4.  "biClrImportant"

	((bfType = 19778) & (bfReserved = 0) & (biPlanes = 1) &
	 (biSize = 40) & (bfSize <= f size))
		ifFalse: [self error: 'Bad BMP file header'].
	biCompression = 0
		ifFalse: [self error: 'Can currently only read uncompressed BMP files'].

	f position: bfOffBits.  "Skip past any color map to the image data"
	form _ Form extent: biWidth@biHeight
				depth: (biBitCount = 24 ifTrue: [32] ifFalse: [biBitCount]).
	rowBytes _ (biBitCount * biWidth + 31 // 32) * 4.
	line _ Form extent: biWidth@1 depth: form depth.
	data _ line bits.
	1 to: biHeight do: [:i |
		biBitCount = 24
		ifTrue: [pixelLine _ f next: rowBytes.
				pixIndex _ 1.
				1 to: biWidth do: [:j |
					rgb _ (pixelLine at: pixIndex) +
						   ((pixelLine at: pixIndex + 1) bitShift: 8) +
						   ((pixelLine at: pixIndex + 2) bitShift: 16).
					line bits at: j put: rgb.
					pixIndex _ pixIndex + 3]]
		ifFalse: [f nextInto: data. self halt].
		form copy: line boundingBox from: line to: 0@(biHeight-i) rule: Form over].

	f close.
	^ form