alphaBlend: sourceWord with: destinationWord
	"Blend sourceWord with destinationWord, assuming both are 32-bit pixels.
	The source is assumed to have 255*alpha in the high 8 bits of each pixel,
	while the high 8 bits of the destinationWord will be ignored.
	The blend produced is alpha*source + (1-alpha)*dest, with
	the computation being performed independently on each color
	component.  The high byte of the result will be 0."
	| alpha unAlpha colorMask result blend shift |
	self inline: false.
	alpha _ sourceWord >> 24.  "High 8 bits of source pixel"
	alpha = 0 ifTrue: [ ^ destinationWord ].
	alpha = 255 ifTrue: [ ^ sourceWord ].
	unAlpha _ 255 - alpha.
	colorMask _ 16rFF.
	result _ 0.
	"ar 9/9/2000 - include alpha in computation"
	1 to: 4 do:
		[:i | shift _ (i-1)*8.
		blend _ (((sourceWord>>shift bitAnd: colorMask) * alpha)
					+ ((destinationWord>>shift bitAnd: colorMask) * unAlpha))
			 	+ 254 // 255 bitAnd: colorMask.
		result _ result bitOr: blend<<shift].
	^ result
