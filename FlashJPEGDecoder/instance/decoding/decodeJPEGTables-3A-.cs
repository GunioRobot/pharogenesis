decodeJPEGTables: aStream
	self setStream: aStream.
	eoiSeen _ false.
	self parseFirstMarker.
	[eoiSeen] whileFalse:[self parseNextMarker].