setWithText: aText style: aTextStyle 
	"Set text and adjust bounding rectangles to fit."

	| shrink i compositionWidth unbounded |
	unbounded _ Rectangle origin: 0 @ 0 extent: 10000@10000.
	compositionWidth _ self
		setWithText: aText style: aTextStyle compositionRectangle: unbounded clippingRectangle: unbounded.
	compositionRectangle width: compositionWidth.
	clippingRectangle _ compositionRectangle copy.
	shrink _ unbounded width - compositionWidth.
	"Shrink padding widths accordingly"
	1 to: lastLine do:
		[:i | (lines at: i) paddingWidth: (lines at: i) paddingWidth - shrink]