smallDebugIcon
	"Private - Generated method"
	^ Icons
			at: #'smallDebug'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallDebugIconContents readStream) ].