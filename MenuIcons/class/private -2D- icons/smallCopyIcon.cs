smallCopyIcon
	"Private - Generated method"
	^ Icons
			at: #'smallCopy'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallCopyIconContents readStream) ].