setFontSize
	| sizes reply family |
	family _ font ifNil: [TextStyle default] ifNotNil: [font textStyle].
	family ifNil: [family _ TextStyle default].  "safety net -- this line SHOULD be unnecessary now"
	sizes _ 	family fontNamesWithPointSizes.
	reply _ (SelectionMenu labelList: sizes selections: sizes) startUp.
	reply ifNotNil:
		[self font: (family fontAt: (sizes indexOf: reply))]