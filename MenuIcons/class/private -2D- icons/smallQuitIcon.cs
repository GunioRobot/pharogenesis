smallQuitIcon
	"Private - Generated method"
	^ Icons
			at: #'smallQuit'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallQuitIconContents readStream) ].