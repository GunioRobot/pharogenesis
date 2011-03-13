AbstractFont
	subclass: #StrikeFont
	instanceVariableNames:
		'characterToGlyphMap xTable glyphs name type minAscii maxAscii maxWidth strikeLength ascent descent xOffset raster subscript superscript emphasis derivativeFonts pointSize fallbackFont charIndex'
	classVariableNames: 'DefaultStringScanner'
	poolDictionaries: 'TextConstants'
	category: 'Graphics-Fonts'