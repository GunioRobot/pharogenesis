questionIcon
	"Private - Generated method"
	^icons
			at: #questionIcon
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self questionIconContents readStream) ].