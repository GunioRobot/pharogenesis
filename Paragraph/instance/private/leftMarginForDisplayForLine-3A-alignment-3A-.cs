leftMarginForDisplayForLine: lineIndex alignment: alignment
	"Build the left margin for display of a line. Depends upon
	leftMarginForComposition, compositionRectangle left and the alignment."

	| pad |
	(alignment = LeftFlush or: [alignment = Justified])
		ifTrue: 
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex)].
	"When called from character location code and entire string has been cut,
	there are no valid lines, hence following nil check."
	(lineIndex <= lines size and: [(lines at: lineIndex) notNil])
		ifTrue: 
			[pad _ (lines at: lineIndex) paddingWidth]
		ifFalse: 
			[pad _ 
				compositionRectangle width - textStyle firstIndent - textStyle rightIndent].
	alignment = Centered 
		ifTrue: 
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex) + (pad // 2)].
	alignment = RightFlush 
		ifTrue:
			[^compositionRectangle left 
				+ (self leftMarginForCompositionForLine: lineIndex) + pad].
	self error: ['no such alignment']