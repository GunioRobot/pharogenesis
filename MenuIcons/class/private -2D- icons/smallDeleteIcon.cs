smallDeleteIcon
	"Private - Generated method"
	^ Icons
			at: #'smallDelete'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallDeleteIconContents readStream) ].