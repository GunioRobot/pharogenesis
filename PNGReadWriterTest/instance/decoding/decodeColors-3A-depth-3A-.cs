decodeColors: colorsAndFiles depth: requiredDepth
	| color bytes form |
	colorsAndFiles do:[:assoc|
		color := assoc key.
		bytes := Base64MimeConverter mimeDecodeToBytes: assoc value readStream.
		form := PNGReadWriter formFromStream: bytes.
		self assert: form depth = requiredDepth.
		self assert: (form pixelValueAt: 1@1) = (color pixelValueForDepth: requiredDepth).
	].