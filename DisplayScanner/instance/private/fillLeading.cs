fillLeading
	"At the end of every run (really only needed when font size changes),
	fill any extra leading above and below the font in the larger line height"

	fillBlt == nil ifTrue: [^ self].  "No fill requested"

	"Fill space above the font"
	fillBlt destX: runX destY: lineY width: destX - runX height: destY - lineY;
		copyBits.

	"Fill space below the font"
	fillBlt destY: (destY + height); height: (lineY + lineHeight) - (destY + height);
		copyBits.
