smallOpenIcon
	"Private - Generated method"
	^ Icons
			at: #'smallOpen'
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self smallOpenIconContents readStream) ].