smallProjectIcon
	"Private - Generated method"
	^ Icons
			at: #'smallProject'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallProjectIconContents readStream) ].