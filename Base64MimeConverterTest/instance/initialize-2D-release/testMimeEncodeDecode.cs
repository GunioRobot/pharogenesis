testMimeEncodeDecode

	| encoded |

	encoded _ Base64MimeConverter mimeEncode: message.
	
	self should: [encoded contents = 'SGkgVGhlcmUh'].
     self should: [(Base64MimeConverter mimeDecodeToChars: encoded)
                      contents = message contents].