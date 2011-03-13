fillRectangle: aRectangle basicFillStyle: aFillStyle
	"Fill the given rectangle with the given, non-composite, fill style."
	
	^self drawRectangle: aRectangle
			color: aFillStyle "@@: Name confusion!!!"
			borderWidth: 0
			borderColor: nil
