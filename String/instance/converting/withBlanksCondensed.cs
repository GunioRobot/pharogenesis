withBlanksCondensed
	"Return a copy of the receiver with leading/trailing blanks removed
	 and consecutive white spaces condensed."

	| trimmed lastBlank |
	trimmed _ self withBlanksTrimmed.
	^String streamContents: [:stream |
		lastBlank _ false.
		trimmed do: [:c | (c isSeparator and: [lastBlank]) ifFalse: [stream nextPut: c].
			lastBlank _ c isSeparator]].

	" ' abc  d   ' withBlanksCondensed"
