computeForm: char

	| ttGlyph scale |
	scale _ self pixelSize asFloat / (ttcDescription ascender - ttcDescription descender).
	Scale ifNotNil: [scale _ Scale * scale].
	ttGlyph _ ttcDescription at: (char isCharacter ifTrue: [char charCode] ifFalse: [char]).
	^ ttGlyph asFormWithScale: scale ascender: ttcDescription ascender descender: ttcDescription descender fgColor: foregroundColor bgColor: Color transparent depth: self depth.
