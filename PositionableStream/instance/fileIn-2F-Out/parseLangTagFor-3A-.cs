parseLangTagFor: aString

	| string peek runsRaw pos |
	string _ aString.
	"Test for ]lang[ tag"
	pos _ self position.
	peek _ self skipSeparatorsAndPeekNext.
	peek = $] ifFalse: [self position: pos. ^ string].  "no tag"
	(self upTo: $[) = ']lang' ifTrue: [
		runsRaw _ self basicNextChunk.
		string _ self decodeString: aString andRuns: runsRaw
	] ifFalse: [
		self position: pos
	].
	^ string.
