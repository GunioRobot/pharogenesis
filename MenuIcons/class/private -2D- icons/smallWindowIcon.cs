smallWindowIcon
	"Private - Generated method"
	^ Icons
			at: #'smallWindow'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallWindowIconContents readStream) ].