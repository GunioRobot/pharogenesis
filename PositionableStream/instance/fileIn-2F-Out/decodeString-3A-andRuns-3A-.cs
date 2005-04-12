decodeString: string andRuns: runsRaw

	| strm runLength runValues newString index |
	strm _ ReadStream on: runsRaw from: 1 to: runsRaw size.
	(strm peekFor: $( ) ifFalse: [^ nil].
	runLength _ OrderedCollection new.
	[strm skipSeparators.
	 strm peekFor: $)] whileFalse: 
		[runLength add: (Number readFrom: strm)].

	runValues _ OrderedCollection new.
	[strm atEnd not] whileTrue: 
		[runValues add: (Number readFrom: strm).
		strm next.].

	newString _ WideString new: string size.
	index _ 1.
	runLength with: runValues do: [:length :leadingChar |
		index to: index + length - 1 do: [:pos |
			newString at: pos put: (Character leadingChar: leadingChar code: (string at: pos) charCode).
		].
		index _ index + length.
	].

	^ newString.
