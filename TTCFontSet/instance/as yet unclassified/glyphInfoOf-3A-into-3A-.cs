glyphInfoOf: aCharacter into: glyphInfoArray

	| index f code |
	index _ aCharacter leadingChar + 1.
	fontArray size < index ifTrue: [^ self questionGlyphInfoInto: glyphInfoArray].
	(f _ fontArray at: index) ifNil: [^ self questionGlyphInfoInto: glyphInfoArray].

	code _ aCharacter charCode.
	((code between: f minAscii and: f maxAscii) not) ifTrue: [
		^ self questionGlyphInfoInto: glyphInfoArray.
	].
	f glyphInfoOf: aCharacter into: glyphInfoArray.
	glyphInfoArray at: 5 put: self.
	^ glyphInfoArray.
