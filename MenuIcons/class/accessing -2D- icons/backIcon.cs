backIcon
	"Private - Generated method"
	^ Icons
			at: #'back'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self backIconContents readStream) ].