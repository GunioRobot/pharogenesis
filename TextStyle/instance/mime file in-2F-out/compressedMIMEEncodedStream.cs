compressedMIMEEncodedStream
	"Answer a ReadWriteStream with my compressed, stored representation as Base64"

	| s ff ffcontents s2 gzs |
	self fontArray do: [:f | f releaseCachedState].
	s := RWBinaryOrTextStream on: ''.
	ff := SmartRefStream on: s reset.
	TextConstants at: #forceFontWriting put: true.
	[ff nextPut: self] 
		ensure: [TextConstants at: #forceFontWriting put: false].
	ffcontents := s contents.
	ff close.
	s2 := RWBinaryOrTextStream on: ''.
	gzs := GZipWriteStream on: s2.
	gzs nextPutAll: ffcontents.
	gzs close.
	s2 reset.
	s := RWBinaryOrTextStream on: (ByteArray new: 10000).
	Base64MimeConverter mimeEncode: s2 to: s.
	^s
		ascii;
		reset;
		yourself