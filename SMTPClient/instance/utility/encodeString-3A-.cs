encodeString: aString 
	| str dec |
	str := String new: (aString size * 4 / 3 + 3) ceiling.
	dec := Base64MimeConverter new.
	dec
		mimeStream: str writeStream;
		dataStream: aString readStream;
		mimeEncode.
	^ str