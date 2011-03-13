leftMarginForCompositionForLine: lineIndex 
	"Build the left margin for composition of a line. Depends upon
	marginTabsLevel and the indent."

	| indent |
	lineIndex = 1
		ifTrue: [indent _ textStyle firstIndent]
		ifFalse: [indent _ textStyle restIndent].
	^indent + (textStyle leftMarginTabAt: marginTabsLevel)