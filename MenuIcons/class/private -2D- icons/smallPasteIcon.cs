smallPasteIcon
	"Private - Generated method"
	^ Icons
			at: #'smallPaste'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallPasteIconContents readStream) ].