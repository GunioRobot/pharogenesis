smallJustifiedIcon
	"Private - Generated method"
	^ Icons
			at: #'smallJustified'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallJustifiedIconContents readStream) ].