encodeForHTTP
	"change dangerous characters to their %XX form, for use in HTTP transactions"
	| encodedStream |
	encodedStream _ WriteStream on: (String new).
	
	self do: [ :c |
		c isSafeForHTTP ifTrue: [ encodedStream nextPut: c ] ifFalse: [
			encodedStream nextPut: $%.
			encodedStream nextPut: (c asciiValue // 16) asHexDigit.
			encodedStream nextPut: (c asciiValue \\ 16) asHexDigit.
		]
	].
	^encodedStream contents. 