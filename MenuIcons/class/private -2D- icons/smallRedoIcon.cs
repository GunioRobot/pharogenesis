smallRedoIcon
	"Private - Generated method"
	^ Icons
			at: #'smallRedo'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallRedoIconContents readStream) ].