questionGlyphInfoInto: glyphInfoArray

	| f ascii |
	f _ fontArray at: 1.
	ascii _ $? asciiValue.
	glyphInfoArray at: 1 put: f glyphs;
		at: 2 put: (f xTable at: ascii + 1);
		at: 3 put: (f xTable at: ascii + 2);
		at: 4 put: (self ascentOf: $?);
		at: 5 put: self.
	^ glyphInfoArray.
