smallRightFlushIcon
	"Private - Generated method"
	^ Icons
			at: #'smallRightFlush'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallRightFlushIconContents readStream) ].