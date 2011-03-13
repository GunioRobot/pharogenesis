decompressFillStyle
	| type |
	type := stream next.
	type = $S ifTrue:[^self decompressSolidFill].
	type = $R ifTrue:[^self decompressGradientFill: true].
	type = $L ifTrue:[^self decompressGradientFill: false].
	type = $B ifTrue:[^self decompressBitmapFill].
	^self error:'Unknown fill type'