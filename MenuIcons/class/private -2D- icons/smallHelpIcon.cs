smallHelpIcon
	"Private - Generated method"
	^ Icons
			at: #'smallHelp'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallHelpIconContents readStream) ].