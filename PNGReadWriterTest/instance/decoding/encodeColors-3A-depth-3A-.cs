encodeColors: colorsAndFiles depth: requiredDepth
	| color original ff encoded |
	colorsAndFiles do:[:assoc|
		color := assoc key.
		original := Base64MimeConverter mimeDecodeToBytes: assoc value readStream.
		ff := Form extent: 32@32 depth: requiredDepth.
		ff fillColor: color.
		encoded := WriteStream on: ByteArray new.
		PNGReadWriter putForm: ff onStream: encoded.
		self assert: (encoded contents = original contents).
	].