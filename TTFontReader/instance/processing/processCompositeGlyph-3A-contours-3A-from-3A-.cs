processCompositeGlyph: glyph contours: nContours from: entry
	"Read a composite glyph from the font data. The glyph passed into this method contains some state variables that must be copied into the resulting composite glyph."
	| flags glyphIndex hasInstr cGlyph ofsX ofsY iLen a11 a12 a21 a22 m |
	cGlyph _ TTCompositeGlyph new.
	a11 _ a22 _ 16r4000.	"1.0 in F2Dot14"
	a21 _ a12 _ 0.		"0.0 in F2Dot14"
	"Copy state"
	cGlyph bounds: glyph bounds; glyphIndex: glyph glyphIndex.
	hasInstr _ false.
	[ flags _ entry nextUShort.
	glyphIndex _ entry nextUShort + 1.
	(flags bitAnd: 1) = 1 ifTrue:[
		ofsX _ entry nextShort.
		ofsY _ entry nextShort.
	] ifFalse:[
		(ofsX _ entry nextByte) > 127 ifTrue:[ofsX _ ofsX - 256].
		(ofsY _ entry nextByte) > 127 ifTrue:[ofsY _ ofsY - 256]].
	((flags bitAnd: 2) = 2) ifFalse:[self halt].
	(flags bitAnd: 8) = 8 ifTrue:[
		a11 _ a22 _ entry nextShort].
	(flags bitAnd: 64) = 64 ifTrue:[
		a11 _ entry nextShort.
		a22 _ entry nextShort].
	(flags bitAnd: 128) = 128 ifTrue:[
		"2x2 transformation"
		a11 _ entry nextShort.
		a21 _ entry nextShort.
		a12 _ entry nextShort.
		a22 _ entry nextShort].
	m _ MatrixTransform2x3 new.
	"Convert entries from F2Dot14 to float"
	m a11: (a11 asFloat / 16r4000).
	m a12: (a12 asFloat / 16r4000).
	m a21: (a21 asFloat / 16r4000).
	m a22: (a22 asFloat / 16r4000).
	m a13: ofsX.
	m a23: ofsY.
	cGlyph addGlyph: (glyphs at: glyphIndex) transformation: m.
	hasInstr _ hasInstr or:[ (flags bitAnd: 256) = 256].
	"Continue as long as the MORE_COMPONENTS bit is set"
	(flags bitAnd: 32) = 32] whileTrue.
	hasInstr ifTrue:[
		iLen _ entry nextUShort.
		entry skip: iLen].
	^cGlyph