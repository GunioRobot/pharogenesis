writeBMPfileNamed: fName  "Display writeBMPfileNamed: 'display'"
	| fileName bhSize biSize biClrUsed f biSizeImage bfOffBits rowBytes rgb data |
	(#(1 4 8 32) includes: depth) ifFalse: [self halt  "depth must be one of these"].
	((fileName _ fName) asUppercase endsWith: '.BMP')
		ifFalse: [fileName _ fName , '.BMP'].
	bhSize _ 14.  "# bytes in file header"
	biSize _ 40.  "info header size in bytes" 
	biClrUsed _ depth = 32 ifTrue: [0] ifFalse:[1 << depth].  "No. color table entries"
	bfOffBits _ biSize + bhSize + (4*biClrUsed).
	rowBytes _ ((depth min: 24) * width + 31 // 32) * 4.
	biSizeImage _ height * rowBytes.

 	f _ (FileStream newFileNamed: fileName) binary.
	"Write the file header"
	f position: 0.
	f nextLitteEndianNumber: 2 put: 19778.  "bfType = BM" 
	f nextLitteEndianNumber: 4 put: bfOffBits + biSizeImage.  "Entire file size in bytes"
	f nextLitteEndianNumber: 4 put: 0.  "bfReserved" 
	f nextLitteEndianNumber: 4 put: bfOffBits.  "Offset of bitmap data from start of hdr (and file)"

	"Write the bitmap info header"
	f position: bhSize.
	f nextLitteEndianNumber: 4 put: biSize.  "info header size in bytes" 
	f nextLitteEndianNumber: 4 put: width.  "biWidth" 
	f nextLitteEndianNumber: 4 put: height.  "biHeight" 
	f nextLitteEndianNumber: 2 put: 1.  "biPlanes" 
	f nextLitteEndianNumber: 2 put: (depth min: 24).  "biBitCount" 
	f nextLitteEndianNumber: 4 put: 0.  "biCompression" 
	f nextLitteEndianNumber: 4 put: biSizeImage.  "size of image section in bytes"
	f nextLitteEndianNumber: 4 put: 2800.  "biXPelsPerMeter" 
	f nextLitteEndianNumber: 4 put: 2800.  "biYPelsPerMeter" 
	f nextLitteEndianNumber: 4 put: biClrUsed.
	f nextLitteEndianNumber: 4 put: 0.  "biClrImportant" 
	1 to: biClrUsed do:  "Color map"
		[:i | rgb _ (Color indexedColors at: i) pixelValueForDepth: 32.
		0 to: 24 by: 8 do: [:j | f nextPut: (rgb >> j bitAnd: 16rFF)]].

	'Writing image data' displayProgressAt: Sensor cursorPoint
		from: 1 to: height during: [:bar |
			1 to: height do:
				[:i | bar value: i.
				data _ (self copy: (0@(height-i) extent: width@1)) bits.
				depth = 32
				ifTrue: [1 to: data size do: [:j | f nextLitteEndianNumber: 3 put: (data at: j)].
						1 to: (data size*3)+3//4*4-(data size*3) do: [:j | f nextPut: 0 "pad to 32-bits"]]
				ifFalse: ["1 to: data size do: [:j | f nextNumber: 4 put: (data at: j)]"
						f nextPutAll: data]]].
	f position = (bfOffBits + biSizeImage) ifFalse: [self halt].
	f close.