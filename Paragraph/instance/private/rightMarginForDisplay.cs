rightMarginForDisplay 
	"Build the right margin for a line. Depends upon compositionRectangle
	rightSide, marginTabsLevel, and right indent."

	^compositionRectangle right - 
		textStyle rightIndent - (textStyle rightMarginTabAt: marginTabsLevel)