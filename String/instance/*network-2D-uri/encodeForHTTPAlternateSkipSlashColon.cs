encodeForHTTPAlternateSkipSlashColon
	"change dangerous characters to their %XX form, for use in HTTP transactions"
	| encodedStream |
	encodedStream := (String new) writeStream.
	
	self do: [ :c |
		(c isSafeForHTTPAlternate or: [c == $/ or: [c == $:]]) ifTrue: [ encodedStream nextPut: c ] ifFalse: [
			encodedStream nextPut: $%.
			encodedStream nextPut: (c asciiValue // 16) asHexDigit.
			encodedStream nextPut: (c asciiValue \\ 16) asHexDigit.
		]
	].
	^encodedStream contents. 