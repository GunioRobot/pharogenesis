smallAuthoringToolsIcon
	"Private - Generated method"
	^ Icons
			at: #'smallAuthoringTools'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallAuthoringToolsIconContents readStream) ].