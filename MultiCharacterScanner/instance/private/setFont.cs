setFont
	| priorFont |
	"Set the font and other emphasis."
	priorFont _ font.
	text == nil ifFalse:[
		emphasisCode _ 0.
		kern _ 0.
		indentationLevel _ 0.
		alignment _ textStyle alignment.
		font _ nil.
		(text attributesAt: lastIndex forStyle: textStyle)
			do: [:att | att emphasizeScanner: self]].
	font == nil ifTrue:
		[self setFont: textStyle defaultFontIndex].
	font _ font emphasized: emphasisCode.
	priorFont ifNotNil: [destX _ destX + priorFont descentKern].
	destX _ destX - font descentKern.
	"NOTE: next statement should be removed when clipping works"
	leftMargin ifNotNil: [destX _ destX max: leftMargin].
	kern _ kern - font baseKern.

	"Install various parameters from the font."
	spaceWidth _ font widthOf: Space.
	xTable _ font xTable.
"	map _ font characterToGlyphMap."
	stopConditions _ DefaultStopConditions.