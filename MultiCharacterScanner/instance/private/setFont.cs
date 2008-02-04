setFont
	| priorFont |
	"Set the font and other emphasis."
	priorFont := font.
	text == nil ifFalse:[
		emphasisCode := 0.
		kern := 0.
		indentationLevel := 0.
		alignment := textStyle alignment.
		font := nil.
		(text attributesAt: lastIndex forStyle: textStyle)
			do: [:att | att emphasizeScanner: self]].
	font == nil ifTrue:
		[self setFont: textStyle defaultFontIndex].
	font := font emphasized: emphasisCode.
	priorFont ifNotNil: [destX := destX + priorFont descentKern].
	destX := destX - font descentKern.
	"NOTE: next statement should be removed when clipping works"
	leftMargin ifNotNil: [destX := destX max: leftMargin].
	kern := kern - font baseKern.

	"Install various parameters from the font."
	spaceWidth := font widthOf: Space.
	xTable := font xTable.
"	map := font characterToGlyphMap."
	stopConditions := DefaultStopConditions.