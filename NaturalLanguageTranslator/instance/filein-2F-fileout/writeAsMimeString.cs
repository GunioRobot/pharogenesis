writeAsMimeString

	| fileName fileStream tmpStream s2 gzs |
	tmpStream := MultiByteBinaryOrTextStream on: ''.
	tmpStream converter: UTF8TextConverter new.
	self fileOutOn: tmpStream.
	s2 := RWBinaryOrTextStream on: ''.
	gzs := GZipWriteStream on: s2.
	tmpStream reset.
	gzs nextPutAll: (tmpStream binary contentsOfEntireFile asString) contents.
	gzs close.
	s2 reset.

	fileName := id isoString, '.translation.gz.mime'.
	fileStream := FileStream newFileNamed: fileName.
	fileStream nextPutAll: (Base64MimeConverter mimeEncode: s2) contents.
	fileStream close.
