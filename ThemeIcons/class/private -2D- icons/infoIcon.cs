infoIcon
	"Private - Generated method"
	^icons
			at: #infoIcon
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self infoIconContents readStream) ].