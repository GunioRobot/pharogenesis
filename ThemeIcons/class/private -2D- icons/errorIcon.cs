errorIcon
	"Private - Generated method"
	^icons
			at: #errorIcon
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self errorIconContents readStream) ].