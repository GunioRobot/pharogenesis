alphaBlendScaled: sourceWord with: destinationWord
	"Blend sourceWord with destinationWord using the alpha value from sourceWord.
	Alpha is encoded as 0 meaning 0.0, and 255 meaning 1.0.
	In contrast to alphaBlend:with: the color produced is

		srcColor + (1-srcAlpha) * dstColor

	e.g., it is assumed that the source color is already scaled."
	| unAlpha dstMask srcMask b g r a |
	self inline: false.	"Do NOT inline this into optimized loops"
	unAlpha _ 255 - (sourceWord >> 24).  "High 8 bits of source pixel"
	dstMask _ destinationWord.
	srcMask _ sourceWord.
	b _ (dstMask bitAnd: 255) * unAlpha >> 8 + (srcMask bitAnd: 255).
	b > 255 ifTrue:[b _ 255].
	dstMask _ dstMask >> 8.
	srcMask _ srcMask >> 8.
	g _ (dstMask bitAnd: 255) * unAlpha >> 8 + (srcMask bitAnd: 255).
	g > 255 ifTrue:[g _ 255].
	dstMask _ dstMask >> 8.
	srcMask _ srcMask >> 8.
	r _ (dstMask bitAnd: 255) * unAlpha >> 8 + (srcMask bitAnd: 255).
	r > 255 ifTrue:[r _ 255].
	dstMask _ dstMask >> 8.
	srcMask _ srcMask >> 8.
	a _ (dstMask bitAnd: 255) * unAlpha >> 8 + (srcMask bitAnd: 255).
	a > 255 ifTrue:[a _ 255].
	^(((((a << 8) + r) << 8) + g) << 8) + b