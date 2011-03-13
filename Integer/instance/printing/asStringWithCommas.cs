asStringWithCommas  "123456789 asStringWithCommas"
	| digits |
	digits _ self abs printString.
	^ String streamContents:
		[:strm | 1 to: digits size do: 
			[:i | strm nextPut: (digits at: i).
			(i < digits size and: [(i - digits size) \\ 3 = 0])
				ifTrue: [strm nextPut: $,]]]