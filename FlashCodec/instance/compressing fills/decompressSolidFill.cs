decompressSolidFill
	| color |
	color := self readColorFrom: stream.
	^SolidFillStyle color: color