smallBoldIcon
	"Private - Generated method"
	^icons
			at: #smallBoldIcon
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallBoldIconContents readStream) ].