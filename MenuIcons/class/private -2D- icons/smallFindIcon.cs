smallFindIcon
	"Private - Generated method"
	^ Icons
			at: #'smallFind'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallFindIconContents readStream) ].