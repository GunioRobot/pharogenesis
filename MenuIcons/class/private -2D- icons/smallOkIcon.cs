smallOkIcon
	"Private - Generated method"
	^ Icons
			at: #'smallOk'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallOkIconContents readStream) ].