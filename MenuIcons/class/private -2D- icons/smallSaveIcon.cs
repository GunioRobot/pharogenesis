smallSaveIcon
	"Private - Generated method"
	^ Icons
			at: #'smallSave'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallSaveIconContents readStream) ].