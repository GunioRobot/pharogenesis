getFontData
	| fontHandle bufSize buffer |
	fontHandle _ self primitiveCreateFont: name size: pointSize emphasis: emphasis.
	fontHandle ifNil:[^nil].
	bufSize _ self primitiveFontDataSize: fontHandle.
	buffer _ ByteArray new: bufSize.
	self primitiveFont: fontHandle getData: buffer.
	^buffer