decodeJPEGTables: aStream
"
fixing the #atEnd allows the following to work:

(FlashMorphReader on: (HTTPSocket httpGet: 'http://www.audi.co.uk/flash/intro1.swf' accept:'application/x-shockwave-flash')) processFile startPlaying openInWorld. 
"
	self setStream: aStream.
	eoiSeen _ false.
	self parseFirstMarker.
	[eoiSeen or: [stream atEnd]] whileFalse:[self parseNextMarker].
