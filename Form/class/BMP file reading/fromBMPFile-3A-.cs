fromBMPFile: aBinaryStream
	"Read a BMP format image from the given binary stream."
	"Form fromBMPFile:
		(HTTPSocket
			httpGet: 'http://anHTTPServer/squeak/squeakers.bmp'
			accept: 'image/bmp')"

	| fType fSize reserved pixDataStart hdrSize w h planes d
      compressed colorCount colors colorForm |
	(aBinaryStream isMemberOf: String) ifTrue: [^ nil].  "a network error message"
	aBinaryStream binary.
	fType _ aBinaryStream nextLittleEndianNumber: 2.
	fSize _ aBinaryStream nextLittleEndianNumber: 4.
	reserved _ aBinaryStream nextLittleEndianNumber: 4.
	pixDataStart _ aBinaryStream nextLittleEndianNumber: 4.
	hdrSize _ aBinaryStream nextLittleEndianNumber: 4.
	w _ aBinaryStream nextLittleEndianNumber: 4.
	h _ aBinaryStream nextLittleEndianNumber: 4.
	planes _ aBinaryStream nextLittleEndianNumber: 2.
	d _ aBinaryStream nextLittleEndianNumber: 2.
	compressed _ aBinaryStream nextLittleEndianNumber: 4.
	aBinaryStream nextLittleEndianNumber: 4.  "biSizeImage"
	aBinaryStream nextLittleEndianNumber: 4.  "biXPelsPerMeter"
	aBinaryStream nextLittleEndianNumber: 4.  "biYPelsPerMeter"
	colorCount _ aBinaryStream nextLittleEndianNumber: 4.
	aBinaryStream nextLittleEndianNumber: 4.  "biClrImportant"

	((fType = 19778) & (reserved = 0) & (planes = 1) &
	 (hdrSize = 40) & (fSize <= aBinaryStream size))
		ifFalse: [self error: 'Bad BMP file header'].
	compressed = 0
		ifFalse: [self error: 'Can only read uncompressed BMP files'].

	d = 24 ifTrue: [
		aBinaryStream position: pixDataStart.
		^ self bmp24BitPixelDataFrom: aBinaryStream width: w height: h].

	"read the color map"
	"Note: some programs (e.g. Photoshop 4.0) apparently do not set colorCount; assume that any data between the end of the header and the start of the pixel data is the color map"
	colorCount _ (pixDataStart - 54) // 4.
	colors _ self bmpColorsFrom: aBinaryStream count: colorCount depth: d.

	"read the pixel data"
	aBinaryStream position: pixDataStart.
	colorForm _ self bmpPixelDataFrom: aBinaryStream width: w height: h depth: d.
	colorForm colors: colors.
	^ colorForm
