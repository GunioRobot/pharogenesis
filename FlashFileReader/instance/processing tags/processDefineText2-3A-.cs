processDefineText2: data
	data hasAlpha: true.
	self processGlyphsFrom: data.
	data hasAlpha: false.
	^true