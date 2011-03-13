leftMarginForCompositionForLine: lineIndex 
	"Build the left margin for composition of a line. Depends upon
	marginTabsLevel and the indent."

	| indent |
	lineIndex = 1
		ifTrue: [indent := textStyle firstIndent]
		ifFalse: [indent := textStyle restIndent].
	^indent + (textStyle leftMarginTabAt: marginTabsLevel)