smallSaveAsIcon
	"Private - Generated method"
	^ Icons
			at: #'smallSaveAs'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallSaveAsIconContents readStream) ].