encodeString: aString 
	| str dec |
	str _ String new: (aString size * 4 / 3 + 3) ceiling.
	dec _ Base64MimeConverter new.
	dec
		mimeStream: (WriteStream on: str);
		dataStream: (ReadStream on: aString);
		mimeEncode.
	^ str