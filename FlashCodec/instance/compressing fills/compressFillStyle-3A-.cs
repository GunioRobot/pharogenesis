compressFillStyle: aFillStyle
	aFillStyle isSolidFill ifTrue:[^self compressSolidFill: aFillStyle].
	aFillStyle isGradientFill ifTrue:[^self compressGradientFill: aFillStyle].
	aFillStyle isBitmapFill ifTrue:[^self compressBitmapFill: aFillStyle].
	self error:'Unknown fill style'