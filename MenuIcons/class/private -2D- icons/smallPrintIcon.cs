smallPrintIcon
	"Private - Generated method"
	^ Icons
			at: #'smallPrint'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallPrintIconContents readStream) ].