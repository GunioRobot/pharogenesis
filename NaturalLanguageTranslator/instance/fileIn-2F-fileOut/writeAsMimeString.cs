writeAsMimeString

	| fileName fileStream tmpStream s2 gzs |
	tmpStream _ MultiByteBinaryOrTextStream on: ''.
	tmpStream converter: UTF8TextConverter new.
	self fileOutOn: tmpStream.
	s2 _ RWBinaryOrTextStream on: ''.
	gzs := GZipWriteStream on: s2.
	tmpStream reset.
	gzs nextPutAll: (tmpStream binary contentsOfEntireFile asString) contents.
	gzs close.
	s2 reset.

	fileName _ id isoString, '.translation.gz.mime'.
	fileStream _ FileStream newFileNamed: fileName.
	fileStream nextPutAll: (Base64MimeConverter mimeEncode: s2) contents.
	fileStream close.
