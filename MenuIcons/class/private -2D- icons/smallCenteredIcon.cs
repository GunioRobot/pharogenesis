smallCenteredIcon
	"Private - Generated method"
	^ Icons
			at: #'smallCentered'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallCenteredIconContents readStream) ].