smallUndoIcon
	"Private - Generated method"
	^ Icons
			at: #'smallUndo'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallUndoIconContents readStream) ].