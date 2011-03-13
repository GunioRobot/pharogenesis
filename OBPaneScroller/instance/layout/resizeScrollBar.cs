resizeScrollBar
	| inner outer |
	outer _ super innerBounds.
	inner _ outer withHeight: outer height - self scrollBarHeight - 1.
	scrollBar bounds: ((inner left @ inner bottom + 1)
						corner: outer bottomRight)