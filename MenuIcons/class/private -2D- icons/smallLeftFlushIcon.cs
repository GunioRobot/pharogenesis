smallLeftFlushIcon
	"Private - Generated method"
	^ Icons
			at: #'smallLeftFlush'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallLeftFlushIconContents readStream) ].