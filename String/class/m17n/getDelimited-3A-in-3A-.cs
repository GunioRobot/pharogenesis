getDelimited: index in: string

	| start end |
	start _ index.
	[start > 0 and: [(string at: start) isAlphaNumeric]] whileTrue: [start _ start - 1].
	start _ start + 1.

	end _ index.
	[end <= string size and: [(string at: end) isAlphaNumeric]] whileTrue: [end _ end + 1].
	end _ end - 1.

	^ string copyFrom: start to: end.
