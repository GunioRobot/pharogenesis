smallCutIcon
	"Private - Generated method"
	^ Icons
			at: #'smallCut'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallCutIconContents readStream) ].