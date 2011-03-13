setWithText: aText style: aTextStyle 
	"Set text and adjust bounding rectangles to fit."

	| shrink compositionWidth unbounded |
	unbounded := Rectangle origin: 0 @ 0 extent: 9999@9999.
	compositionWidth := self
		setWithText: aText style: aTextStyle compositionRectangle: unbounded clippingRectangle: unbounded.
	compositionRectangle := compositionRectangle withWidth: compositionWidth.
	clippingRectangle := compositionRectangle copy.
	shrink := unbounded width - compositionWidth.
	"Shrink padding widths accordingly"
	1 to: lastLine do:
		[:i | (lines at: i) paddingWidth: (lines at: i) paddingWidth - shrink]