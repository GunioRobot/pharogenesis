httpEncodeSafely: aUrl
	"Encode the url but skip $/ and $:."

	| encodedStream unescaped |
	unescaped _ aUrl unescapePercents.
	encodedStream _ WriteStream on: (String new).
	
	unescaped do: [ :c |
		(c isSafeForHTTP or: [c == $/ or: [c == $:]]) ifTrue: [ encodedStream nextPut: c ] ifFalse: [
			encodedStream nextPut: $%.
			encodedStream nextPut: (c asciiValue // 16) asHexDigit.
			encodedStream nextPut: (c asciiValue \\ 16) asHexDigit.
		]
	].
	^encodedStream contents. 