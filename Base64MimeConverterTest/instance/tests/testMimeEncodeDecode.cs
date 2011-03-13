testMimeEncodeDecode

	| encoded |
	encoded := Base64MimeConverter mimeEncode: message.
	self assert: (encoded contents = 'SGkgVGhlcmUh').
     self assert: ((Base64MimeConverter mimeDecodeToChars: encoded) contents = message contents).