hasGlyphOf: aCharacter

	| code |
	code _ aCharacter charCode.
	((code between: self minAscii and: self maxAscii) not) ifTrue: [
		^ false.
	].
	(xTable at: code + 1) < 0 ifTrue: [
		^ false.
	].
	^ true.