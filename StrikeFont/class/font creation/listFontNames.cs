listFontNames
	"StrikeFont listFontNames"
	"List all the OS font names"
	| font fontNames index |
	fontNames _ WriteStream on: Array new.
	index _ 0.
	[font _ self listFont: index.
	font == nil] whileFalse:[
		fontNames nextPut: font.
		index _ index + 1].
	^fontNames contents