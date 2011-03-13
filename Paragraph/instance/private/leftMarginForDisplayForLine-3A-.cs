leftMarginForDisplayForLine: lineIndex 
	"Build the left margin for display of a line. Depends upon
	leftMarginForComposition, compositionRectangle left and the alignment."

	| pad |
	(textStyle alignment = LeftFlush or: [textStyle alignment = Justified])
		ifTrue: 
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex)].
	"When called from character location code and entire string has been cut,
	there are no valid lines, hence following nil check."
	(lines at: lineIndex) ~~ nil
		ifTrue: 
			[pad _ (lines at: lineIndex) paddingWidth]
		ifFalse: 
			[pad _ 
				compositionRectangle width - textStyle firstIndent - textStyle rightIndent].
	textStyle alignment = Centered 
		ifTrue: 
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex) + (pad // 2)].
	textStyle alignment = RightFlush 
		ifTrue:
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex) + pad].
	self error: ['no such alignment']