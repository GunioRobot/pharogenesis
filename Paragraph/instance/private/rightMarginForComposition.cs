rightMarginForComposition
	"Build the right margin for a line. Depends upon compositionRectangle
	width, marginTabsLevel, and right indent."

	^compositionRectangle width 
		- (textStyle rightMarginTabAt: marginTabsLevel) 
		- textStyle rightIndent