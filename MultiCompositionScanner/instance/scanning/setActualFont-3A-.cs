setActualFont: aFont
	"Keep track of max height and ascent for auto lineheight"
	| descent |
	super setActualFont: aFont.
	"'   ', lastIndex printString, '   ' displayAt: (lastIndex * 15)@0."
	lineHeight == nil
		ifTrue: [descent _ font descent.
				baseline _ font ascent.
				lineHeight _ baseline + descent]
		ifFalse: [descent _ lineHeight - baseline max: font descent.
				baseline _ baseline max: font ascent.
				lineHeight _ lineHeight max: baseline + descent]