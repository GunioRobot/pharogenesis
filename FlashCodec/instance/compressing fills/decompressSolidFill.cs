decompressSolidFill
	| color |
	color _ self readColorFrom: stream.
	^SolidFillStyle color: color