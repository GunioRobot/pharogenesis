layoutWidgets
	| inner outer |
	outer _ super innerBounds.
	inner _ self innerBounds.
	transform bounds: inner.
	scrollBar bounds: ((inner left @ inner bottom + 1)
						corner: outer bottomRight)