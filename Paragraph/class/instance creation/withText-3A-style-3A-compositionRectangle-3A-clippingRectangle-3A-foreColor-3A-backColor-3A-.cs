withText: aText style: aTextStyle compositionRectangle: compRect clippingRectangle: clipRect foreColor: c1 backColor: c2
	"Answer an instance of me with text set to aText and style set to 
	aTextStyle, composition rectangle is compRect and the clipping rectangle 
	is clipRect."
	| para |
	para := super new.
	para setWithText: aText
		style: aTextStyle
		compositionRectangle: compRect
		clippingRectangle: clipRect
		foreColor: c1 backColor: c2.
	^para