smallHomeIcon
	"Private - Generated method"
	^ Icons
			at: #'smallHome'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallHomeIconContents readStream) ].