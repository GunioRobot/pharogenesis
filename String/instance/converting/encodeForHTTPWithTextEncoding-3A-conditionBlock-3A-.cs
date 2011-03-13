encodeForHTTPWithTextEncoding: encodingName conditionBlock: conditionBlock
	"change dangerous characters to their %XX form, for use in HTTP transactions"

	| httpSafeStream encodedStream cont |
	httpSafeStream _ WriteStream on: (String new).
	encodedStream _ MultiByteBinaryOrTextStream on: (String new: 6).
	encodedStream converter: (TextConverter newForEncoding: encodingName).
	self do: [:c |
		(conditionBlock value: c)
			ifTrue: [httpSafeStream nextPut: (Character value: c charCode)]
			ifFalse: [
				encodedStream text; reset.
				encodedStream nextPut: c.
				encodedStream position: 0.
				encodedStream binary.
				cont _ encodedStream contents.
				cont do: [:byte |
					httpSafeStream nextPut: $%.
					httpSafeStream nextPut: (byte // 16) asHexDigit.
					httpSafeStream nextPut: (byte \\ 16) asHexDigit.
				].
			].
	].
	^ httpSafeStream contents.
