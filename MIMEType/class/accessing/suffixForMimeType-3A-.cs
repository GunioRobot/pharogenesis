suffixForMimeType: mimeType
	^self defaultSuffixes at: mimeType printString ifAbsent: [mimeType sub]