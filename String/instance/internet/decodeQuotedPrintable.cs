decodeQuotedPrintable
	"Assume receiver is in MIME 'quoted-printable' encoding, and decode it."
  
	| input answer c asciiText ascii |
	input _ ReadStream on: self.
	answer _ WriteStream on: (String new: self size).
	[input atEnd] whileFalse: [
		c _ input next.
		c = $=
			ifTrue: [  "quoted character"
				input peek = Character cr
					ifTrue: [  "ignore the '=' at the end of a line"
						input next]
					ifFalse: [  "character encoding"
						asciiText _ input next: 2.
						ascii _ Integer readFrom: (ReadStream on: asciiText) base: 16.
						answer nextPut: (Character value: ascii)]]
			ifFalse: [  "ordinary character"
				answer nextPut: c]].
	^ answer contents
