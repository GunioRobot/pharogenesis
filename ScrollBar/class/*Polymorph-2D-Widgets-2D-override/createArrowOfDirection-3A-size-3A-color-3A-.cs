createArrowOfDirection: aSymbolDirection size: finalSizeInteger color: aColor 
	"Defer to current UITheme if available."
	
	^UITheme current
		scrollbarArrowOfDirection: aSymbolDirection
		size: finalSizeInteger
		color: aColor