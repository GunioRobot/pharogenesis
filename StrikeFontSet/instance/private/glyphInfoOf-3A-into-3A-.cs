glyphInfoOf: aCharacter into: glyphInfoArray

	| index f code leftX |
	index _ aCharacter leadingChar + 1.
	fontArray size < index ifTrue: [^ self questionGlyphInfoInto: glyphInfoArray].
	(f _ fontArray at: index) ifNil: [^ self questionGlyphInfoInto: glyphInfoArray].

	code _ aCharacter charCode.
	((code between: f minAscii and: f maxAscii) not) ifTrue: [
		^ self questionGlyphInfoInto: glyphInfoArray.
	].
	leftX _ f xTable at: code + 1.
	leftX < 0 ifTrue: [
		^ self questionGlyphInfoInto: glyphInfoArray.
	].
	glyphInfoArray at: 1 put: f glyphs;
		at: 2 put: leftX;
		at: 3 put: (f xTable at: code + 2);
		at: 4 put: (f ascentOf: aCharacter);
		at: 5 put: self.
	^ glyphInfoArray.
