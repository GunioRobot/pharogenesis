makeUnixSeed
	| strm answer |
	[strm := (FileStream readOnlyFileNamed: '/dev/urandom') binary.
	answer := Integer
		byte1: strm next
		byte2: strm next
		byte3: strm next
		byte4: strm next.
	strm close.
	] on: FileStreamException do: [answer := nil].
	^answer