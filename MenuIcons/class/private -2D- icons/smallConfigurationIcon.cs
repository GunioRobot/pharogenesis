smallConfigurationIcon
	"Private - Generated method"
	^ Icons
			at: #'smallConfiguration'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallConfigurationIconContents readStream) ].